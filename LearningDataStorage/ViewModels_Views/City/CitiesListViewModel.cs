using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
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
        private readonly IService<City> _cityService;
        private readonly IService<Country> _countryService;

        public CitiesListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer) 
            : base(mainContainer)
        {
            _cityService = servicesContainer.CityService;
            _countryService = servicesContainer.CountryService;

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
                var cities = await _cityService.GetAll();
                var countries = await _countryService.GetAll();

                Cities = new ObservableCollection<City>(cities);
                Countries = new ObservableCollection<Country>(countries);
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

        private async void SaveChanges()
        {
            try
            {
                if (SelectedCity.Id != 0)
                {
                    var city = await _cityService.GetById(SelectedCity.Id);
                    await _cityService.Update(city, SelectedCity);
                }
                else
                {
                    await _cityService.Create(SelectedCity);
                    Cities.Add(SelectedCity);
                }
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
