using LearningDataStorage.DAL;
using log4net;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BaseViewModel, IInitialized
    {
        public CitiesListViewModel(ILog log, ResourceDictionary localization, IDialog dialog) 
            : base(log, localization, dialog)
        {
            Cities = new ObservableCollection<City>();
            Countries = new ObservableCollection<Country>();

            SaveCityCommand = new DelegateCommand(SaveChanges);
            AddCityCommand = new DelegateCommand(AddCity);
            ChangeCityCommand = new DelegateCommand(ChangeCity);
        }

        #region Properties

        public City SelectedCity { get; set; }

        public ObservableCollection<City> Cities { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand SaveCityCommand { get; set; }

        public DelegateCommand AddCityCommand { get; set; }

        public DelegateCommand ChangeCityCommand { get; set; }

        #endregion Commands

        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {
                await Task.Run(() =>
                {
                    using ApplicationContext ctx = new ApplicationContext();
                    Cities = new ObservableCollection<City>(ctx.Cities
                            .Include(city => city.Country)
                            .ToList());

                    Countries = new ObservableCollection<Country>(ctx.Countries
                                .ToList());
                });
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_InitCitiesError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void AddCity()
        {
            SelectedCity = new City
            {
                CountryId = Countries.FirstOrDefault()?.Id ?? 0
            };

            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        private async void ChangeCity()
        {
            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        private void SaveChanges()
        {
            try
            {
                using ApplicationContext ctx = new ApplicationContext();

                if (SelectedCity.Id != 0)
                {
                    ctx.Cities.Update(SelectedCity);
                }
                else
                {
                    ctx.Entry(SelectedCity).State = EntityState.Added;
                    ctx.Cities.Add(SelectedCity);
                    Cities.Add(SelectedCity);
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_SaveCitiesError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally 
            {
                IsDialogOpen = false;
            }
        }

        #endregion Methods
    }
}
