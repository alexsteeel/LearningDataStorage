using AutoMapper;
using log4net;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public abstract class BaseCrudViewModel<TViewModel> : BindableBase, IInitialized
        where TViewModel : IBaseEntityViewModel
    {
        protected readonly ILog _log;
        protected readonly ResourceDictionary _localization;
        protected readonly IDialog _dialog;
        protected readonly ISingletonContainer _mainContainer;
        protected readonly IMapper _mapper;

        protected BaseCrudViewModel(ISingletonContainer mainContainer)
        {
            _log = mainContainer.Log;
            _localization = mainContainer.Localization;
            _dialog = mainContainer.Dialog;
            _mainContainer = mainContainer;
            _mapper = mainContainer.Mapper;

            Items = new ObservableCollection<TViewModel>();
            SelectedItem = (TViewModel)Activator.CreateInstance(typeof(TViewModel));

            CreateCommand = new DelegateCommand(Create);
            UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);
            SaveCommand = new DelegateCommand(Save, () => HasErrors).ObservesProperty(() => HasErrors);
        }

        private void EditItem_OnErrorChanged(object sender, EventArgs e)
        {
            HasErrors = string.IsNullOrEmpty(EditItem?.Error);
        }

        #region Properties

        public TViewModel SelectedItem { get; set; }

        public TViewModel EditItem { get; set; }

        public ObservableCollection<TViewModel> Items { get; set; }

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

        public bool HasErrors { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand CreateCommand { get; set; }

        public DelegateCommand UpdateCommand { get; set; }

        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        #endregion Commands

        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {
                await InitAsync();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_InitError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void Create()
        {
            OpenCreateWindow();
        }

        public void Update()
        {
            EditItem = (TViewModel)SelectedItem.Clone();
            EditItem.OnErrorChanged += EditItem_OnErrorChanged;
            OpenUpdateWindow();
        }

        private async void Save()
        {
            try
            {
                await SaveAsync();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_SaveError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally
            {
                IsDialogOpen = false;
            }
        }

        public async void Delete()
        {
            try
            {
                await DeleteAsync();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_DeleteError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
        }

        public abstract Task InitAsync();

        public abstract Task SaveAsync();

        public abstract void OpenCreateWindow();

        public abstract void OpenUpdateWindow();

        public abstract Task DeleteAsync();

        #endregion Methods
    }
}
