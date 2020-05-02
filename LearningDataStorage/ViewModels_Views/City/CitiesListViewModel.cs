using AutoMapper;
using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BaseViewModel, IInitialized
    {
        private readonly IService<City> _cityService;
        private readonly IService<Country> _countryService;
        private readonly IMapper _mapper;

        public CitiesListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer)
            : base(mainContainer)
        {
            _cityService = servicesContainer.CityService;
            _countryService = servicesContainer.CountryService;

            _mapper = mainContainer.Mapper;

            Cities = new ObservableCollection<CityViewModel>();
            Countries = new ObservableCollection<Country>();

            SaveCityCommand = new DelegateCommand(SaveCity);
            AddCityCommand = new DelegateCommand(AddCity);
            ChangeCityCommand = new DelegateCommand(ChangeCity);
            DeleteCityCommand = new DelegateCommand(DeleteCity);
        }

        #region Properties

        public CityViewModel SelectedCity { get; set; }

        public ObservableCollection<CityViewModel> Cities { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand SaveCityCommand { get; set; }

        public DelegateCommand AddCityCommand { get; set; }

        public DelegateCommand ChangeCityCommand { get; set; }

        public DelegateCommand DeleteCityCommand { get; set; }

        #endregion Commands

        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {
                var cities = await _cityService.GetAll();
                var countries = await _countryService.GetAll();

                var cityViewModels = _mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(cities);
                Cities = new ObservableCollection<CityViewModel>(cityViewModels);
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
            SelectedCity = new CityViewModel
            {
                CountryId = Countries.FirstOrDefault()?.Id ?? 0
            };

            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        private async void ChangeCity()
        {
            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        private async void SaveCity()
        {
            try
            {
                if (SelectedCity.Id != 0)
                {
                    var oldCity = await _cityService.GetById(SelectedCity.Id);
                    var city = _mapper.Map<CityViewModel, City>(SelectedCity);
                    await _cityService.Update(oldCity, city);
                }
                else
                {
                    var city = _mapper.Map<CityViewModel, City>(SelectedCity);
                    await _cityService.Create(city);
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

        private async void DeleteCity()
        {
            try
            {
                var city = await _cityService.GetById(SelectedCity.Id);
                await _cityService.Delete(city);
                Cities.Remove(SelectedCity);
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_DeleteCitiesError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
        }

        #endregion Methods

    }
}
