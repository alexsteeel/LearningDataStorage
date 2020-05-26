using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BaseCrudViewModel<CityViewModel>
    {
        private readonly IService<City> _cityService;
        private readonly IService<Country> _countryService;

        public CitiesListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer)
            : base(mainContainer)
        {
            _cityService = servicesContainer.CityService;
            _countryService = servicesContainer.CountryService;

            Countries = new ObservableCollection<Country>();
        }

        #region Properties

        public ObservableCollection<Country> Countries { get; set; }

        #endregion Properties        

        #region Methods

        public override async Task InitAsync()
        {
            var cities = await _cityService.GetAll();
            var countries = await _countryService.GetAll();

            var cityViewModels = _mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(cities);
            Items = new ObservableCollection<CityViewModel>(cityViewModels);
            Countries = new ObservableCollection<Country>(countries);
        }

        public override async void Create()
        {
            SelectedItem = new CityViewModel
            {
                CountryId = Countries.FirstOrDefault()?.Id ?? 0
            };

            await DialogHost.Show(SelectedItem, "CityDialog");
        }

        public override async void Update()
        {
            await DialogHost.Show(SelectedItem, "CityDialog");
        }

        public override async Task SaveAsync()
        {
            var city = (CityViewModel)SelectedItem;
            if (city.Id != 0)
            {
                var oldCity = await _cityService.GetById(city.Id);
                var newCity = _mapper.Map<CityViewModel, City>(city);
                await _cityService.Update(oldCity, newCity);
            }
            else
            {
                var newCity = _mapper.Map<CityViewModel, City>(city);
                await _cityService.Create(newCity);
                Items.Add(city);
            }
        }

        public override async Task DeleteAsync()
        {
            var cityId = ((CityViewModel)SelectedItem).Id;
            var city = await _cityService.GetById(cityId);
            await _cityService.Delete(city);
            Items.Remove(SelectedItem);
        }

        #endregion Methods
    }
}
