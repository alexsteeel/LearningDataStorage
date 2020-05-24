using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BaseCrudViewModel
    {
        private readonly IService<City> _cityService;
        private readonly IService<Country> _countryService;

        public CitiesListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer)
            : base(mainContainer)
        {
            _cityService = servicesContainer.CityService;
            _countryService = servicesContainer.CountryService;

            Cities = new ObservableCollection<CityViewModel>();
            Countries = new ObservableCollection<Country>();
        }

        #region Properties

        public CityViewModel SelectedCity { get; set; }

        public ObservableCollection<CityViewModel> Cities { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        #endregion Properties        

        #region Methods

        public override async Task InitAsync()
        {
            var cities = await _cityService.GetAll();
            var countries = await _countryService.GetAll();

            var cityViewModels = _mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(cities);
            Cities = new ObservableCollection<CityViewModel>(cityViewModels);
            Countries = new ObservableCollection<Country>(countries);
        }

        public override async void Create()
        {
            SelectedCity = new CityViewModel
            {
                CountryId = Countries.FirstOrDefault()?.Id ?? 0
            };

            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        public override async void Update()
        {
            await DialogHost.Show(SelectedCity, "CityDialog");
        }

        public override async Task SaveAsync()
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

        public override async Task DeleteAsync()
        {
            var city = await _cityService.GetById(SelectedCity.Id);
            await _cityService.Delete(city);
            Cities.Remove(SelectedCity);
        }

        #endregion Methods
    }
}
