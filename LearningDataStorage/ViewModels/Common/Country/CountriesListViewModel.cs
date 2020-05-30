using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class CountriesListViewModel : BaseCrudViewModel<CountryViewModel>
    {
        private readonly IService<Country> _countryService;

        public CountriesListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer) 
            : base(mainContainer)
        {
            _countryService = servicesContainer.CountryService;
        }

        #region Methods

        public override async Task InitAsync()
        {
            var countries = await _countryService.GetAll();
            var countryViewModels = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(countries);
            Items = new ObservableCollection<CountryViewModel>(countryViewModels);
        }

        public async override void OpenCreateWindow()
        {
            EditItem = new CountryViewModel();
            await DialogHost.Show(EditItem, "CountryDialog");
        }

        public async override void OpenUpdateWindow()
        {
            await DialogHost.Show(EditItem, "CountryDialog");
        }

        public async override Task SaveAsync()
        {
            var country = EditItem;
            if (country.Id != 0)
            {
                var oldCountry = await _countryService.GetById(country.Id);
                var newCountry = _mapper.Map<CountryViewModel, Country>(country);
                await _countryService.Update(oldCountry, newCountry);
                SelectedItem.CopyFrom(EditItem);
            }
            else
            {
                var newCountry = _mapper.Map<CountryViewModel, Country>(country);
                await _countryService.Create(newCountry);
                Items.Add(country);
            }
        }

        public async override Task DeleteAsync()
        {
            var countryId = SelectedItem.Id;
            var country = await _countryService.GetById(countryId);
            await _countryService.Delete(country);
            Items.Remove(SelectedItem);
        }

        #endregion Methods
    }
}
