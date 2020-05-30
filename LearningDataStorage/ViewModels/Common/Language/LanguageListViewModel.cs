using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class LanguageListViewModel : BaseCrudViewModel<LanguageViewModel>
    {
        private readonly IService<Language> _languageService;

        public LanguageListViewModel(ISingletonContainer mainContainer, ICommonServicesContainer servicesContainer) 
            : base(mainContainer)
        {
            _languageService = servicesContainer.LanguageService;
        }

        #region Methods

        public override async Task InitAsync()
        {
            var languages = await _languageService.GetAll();
            var languageViewModels = _mapper.Map<IEnumerable<Language>, IEnumerable<LanguageViewModel>>(languages);
            Items = new ObservableCollection<LanguageViewModel>(languageViewModels);
        }

        public async override void OpenCreateWindow()
        {
            EditItem = new LanguageViewModel();
            await DialogHost.Show(EditItem, "LanguageDialog");
        }

        public async override void OpenUpdateWindow()
        {
            await DialogHost.Show(EditItem, "LanguageDialog");
        }

        public async override Task SaveAsync()
        {
            var language = EditItem;
            if (language.Id != 0)
            {
                var oldLanguage = await _languageService.GetById(language.Id);
                var newLanguage = _mapper.Map<LanguageViewModel, Language>(language);
                await _languageService.Update(oldLanguage, newLanguage);
                SelectedItem.CopyFrom(EditItem);
            }
            else
            {
                var newLanguage = _mapper.Map<LanguageViewModel, Language>(language);
                await _languageService.Create(newLanguage);
                Items.Add(language);
            }
        }

        public async override Task DeleteAsync()
        {
            var languageId = SelectedItem.Id;
            var language = await _languageService.GetById(languageId);
            await _languageService.Delete(language);
            Items.Remove(SelectedItem);
        }

        #endregion Methods
    }
}
