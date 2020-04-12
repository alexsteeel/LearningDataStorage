using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace LearningDataStorage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            LanguageChanged += App_LanguageChanged;

            Languages.Clear();
            Languages.Add(new CultureInfo("en-US"));
            Languages.Add(new CultureInfo("ru-RU"));

            Language = LearningDataStorage.Properties.Settings.Default.DefaultLanguage;
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

                ResourceDictionary oldDict = (from d in Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Resources/Localizations/lang.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Current.Resources.MergedDictionaries.Remove(oldDict);
                    Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Current.Resources.MergedDictionaries.Add(dict);
                }

                LanguageChanged(Current, new EventArgs());
            }
        }

        private void App_LanguageChanged(object sender, EventArgs e)
        {
            LearningDataStorage.Properties.Settings.Default.DefaultLanguage = Language;
            LearningDataStorage.Properties.Settings.Default.Save();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            services.AddSingleton(log);

            var localization = Current.Resources.MergedDictionaries
               .Where(x => x.Source.OriginalString.Contains("Localizations/lang"))
               .FirstOrDefault();
            services.AddSingleton(localization);

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
