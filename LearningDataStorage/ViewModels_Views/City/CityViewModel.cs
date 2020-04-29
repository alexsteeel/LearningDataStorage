using LearningDataStorage.Core.Models;
using System;
using System.ComponentModel;
using System.Linq;

namespace LearningDataStorage
{
    public class CityViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly CityValidator _cityValidator;

        public CityViewModel()
        {
            _cityValidator = new CityValidator();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public string this[string columnName]
        {
            get
            {
                var error = _cityValidator.Validate(this).Errors
                    .FirstOrDefault(x => x.PropertyName == columnName);

                if (error != null)
                {
                    return _cityValidator != null ? error.ErrorMessage : "";
                }
                else
                {
                    return "";
                }                
            }
        }

        public string Error
        {
            get
            {
                if (_cityValidator != null)
                {
                    var results = _cityValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }
    }
}
