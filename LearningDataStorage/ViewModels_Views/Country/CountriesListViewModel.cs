﻿using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using LearningDataStorage.DAL;
using log4net;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace LearningDataStorage
{
    public class CountriesListViewModel : BaseViewModel, IInitialized
    {
        private readonly IService<Country> _countryService;

        public CountriesListViewModel(ILog log, ResourceDictionary localization, IDialog dialog, IService<Country> countryService) 
            : base(log, localization, dialog)
        {
            _countryService = countryService;

            Countries = new ObservableCollection<Country>();

            SaveCountryCommand = new DelegateCommand(SaveChanges);
            AddCountryCommand = new DelegateCommand(AddCountry);
            ChangeCountryCommand = new DelegateCommand(ChangeCountry);
        }

        #region Properties

        public Country SelectedCountry { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand SaveCountryCommand { get; set; }

        public DelegateCommand AddCountryCommand { get; set; }

        public DelegateCommand ChangeCountryCommand { get; set; }

        #endregion Commands

        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {
                var countries = await _countryService.GetAll();
                Countries = new ObservableCollection<Country>(countries);
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_InitCountriesError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void AddCountry()
        {
            SelectedCountry = new Country();

            await DialogHost.Show(SelectedCountry, "CountryDialog");
        }

        private async void ChangeCountry()
        {
            await DialogHost.Show(SelectedCountry, "CountryDialog");
        }

        private void SaveChanges()
        {
            try
            {
                using ApplicationContext ctx = new ApplicationContext();

                if (SelectedCountry.Id != 0)
                {
                    ctx.Countries.Update(SelectedCountry);
                }
                else
                {
                    ctx.Entry(SelectedCountry).State = EntityState.Added;
                    ctx.Countries.Add(SelectedCountry);
                    Countries.Add(SelectedCountry);
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_SaveCountriesError"]}{_localization["m_Er_DetailedError"]}";
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
