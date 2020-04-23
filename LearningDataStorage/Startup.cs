using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using LearningDataStorage.DAL;
using LearningDataStorage.Services;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace LearningDataStorage
{
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;

        public Startup()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            LanguageChanged += App_LanguageChanged;

            Languages.Clear();
            Languages.Add(new CultureInfo("en-US"));
            Languages.Add(new CultureInfo("ru-RU"));

            Language = Properties.Settings.Default.DefaultLanguage;
        }

        public static List<CultureInfo> Languages { get; } = new List<CultureInfo>();

        public static event EventHandler LanguageChanged;

        public static CultureInfo Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (value == Thread.CurrentThread.CurrentUICulture)
                {
                    return;
                }

                Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary
                {
                    Source = value.Name switch
                    {
                        "ru-RU" => new Uri(string.Format($"Resources/Localizations/lang.{value.Name}.xaml"), UriKind.Relative),
                        _ => new Uri("Resources/Localizations/lang.xaml", UriKind.Relative),
                    }
                };

                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Resources/Localizations/lang.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        private void App_LanguageChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultLanguage = Language;
            Properties.Settings.Default.Save();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var connectionString = new ConfigurationManager().GetConnectionString();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly("LearningDataStorage.DAL")));

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            services.AddSingleton<ILog>(log);

            var localization = Application.Current.Resources.MergedDictionaries
               .Where(x => x.Source.OriginalString.Contains("Localizations/lang"))
               .FirstOrDefault();
            services.AddSingleton(localization);

            services.AddSingleton<IDialog>(new Dialog());
            
            services.AddSingleton<ISingletonContainer, SingletonContainer>();
            services.AddTransient<IBookServicesContainer, BookServicesContainer>();
            services.AddTransient<ICommonServicesContainer, CommonServicesContainer>();

            services.AddTransient<IService<Book>, BookService>();
            services.AddTransient<IService<PublishingHouse>, PublishingHouseService>();

            services.AddTransient<IService<City>, CityService>();
            services.AddTransient<IService<Country>, CountryService>();
            services.AddTransient<IService<Language>, LanguageService>();

            services.AddSingleton<MainWindow>();
        }

        public void Start()
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
