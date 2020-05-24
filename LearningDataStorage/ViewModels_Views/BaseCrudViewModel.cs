using AutoMapper;
using log4net;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public abstract class BaseCrudViewModel : BindableBase, IInitialized
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

            CreateCommand = new DelegateCommand(Create);
            UpdateCommand = new DelegateCommand(Update);
            DeleteCommand = new DelegateCommand(Delete);
            SaveCommand = new DelegateCommand(Save);
        }

        #region Properties

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

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

        public abstract void Create();

        public abstract void Update();

        public abstract Task DeleteAsync();

        #endregion Methods
    }
}
