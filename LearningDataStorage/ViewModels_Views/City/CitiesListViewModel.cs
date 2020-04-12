using LearningDataStorage.DAL;
using log4net;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public class CitiesListViewModel : BindableBase, IInitialized
    {
        private readonly ILog _log;
        private readonly ResourceDictionary _localization;

        public CitiesListViewModel(ILog log, ResourceDictionary localization)
        {
            _log = log;
            _localization = localization;

            Cities = new List<City>();

            SaveCommand = new DelegateCommand(SaveChanges);
        }

        public DelegateCommand SaveCommand { get; set; }

        #region Properties

        public ICollection<City> Cities { get; set; }

        public ICollection<Country> Countries { get; set; }

        public City SelectedCity { get; set; }

        public bool IsLoading { get; set; }

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
                    Cities = ctx.Cities
                            .Include(city => city.Country)
                            .ToList();

                    Countries = ctx.Countries
                                .ToList();
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

        private void SaveChanges()
        {
            try
            {
                using ApplicationContext ctx = new ApplicationContext();
                foreach (var city in Cities)
                {
                    if (city.Id != 0)
                    {
                        ctx.Cities.Update(city);
                    }
                    else
                    {
                        ctx.Entry(city).State = EntityState.Added;
                        ctx.Cities.Add(city);
                    }
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Error($"{_localization["m_Er_SaveCitiesError"]}{_localization["m_Er_DetailedError"]}", ex);
            }
        }

        #endregion Methods
    }
}
