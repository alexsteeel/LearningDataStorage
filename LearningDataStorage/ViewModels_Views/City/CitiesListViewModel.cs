using LearningDataStorage.DAL;
using log4net;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BindableBase, IInitialized, INotifyPropertyChanged
    {
        private readonly ILog _log;
        private readonly ResourceDictionary _localization;

        public CitiesListViewModel(ILog log, ResourceDictionary localization)
        {
            _log = log;
            _localization = localization;

            Cities = new ObservableCollection<City>();
            Countries = new ObservableCollection<Country>();

            SaveCityCommand = new DelegateCommand(SaveChanges);
            AddCityCommand = new DelegateCommand(AddCity);
            ChangeCityCommand = new DelegateCommand(ChangeCity);
        }

        public DelegateCommand SaveCityCommand { get; set; }

        public DelegateCommand AddCityCommand { get; set; }

        public DelegateCommand ChangeCityCommand { get; set; }

        #region Properties

        public ObservableCollection<City> Cities { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        public City SelectedCity { get; set; }

        public bool IsLoading { get; set; }

        public bool IsDialogOpen { get; set; }

        #endregion Properties


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
                _log.Error($"{_localization["m_Er_InitCitiesError"]}{_localization["m_Er_DetailedError"]}", ex);
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
            await DialogHost.Show(SelectedCity, "1");
        }

        private async void ChangeCity()
        {
            await DialogHost.Show(SelectedCity, "1");
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
                _log.Error($"{_localization["m_Er_SaveCitiesError"]}{_localization["m_Er_DetailedError"]}", ex);
            }
            finally 
            {
                IsDialogOpen = false;
            }
        }

        #endregion Methods
    }
}
