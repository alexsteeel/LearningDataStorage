using FluentValidation;
using System;
using System.ComponentModel;
using System.Linq;

namespace LearningDataStorage
{
    public abstract class BaseEntityViewModel : IBaseEntityViewModel
    {
        private readonly IValidator _validator;

        public BaseEntityViewModel(IValidator validator)
        {
            _validator = validator;
        }

        public string this[string columnName]
        {
            get
            {
                var error = _validator.Validate(this).Errors
                    .FirstOrDefault(x => x.PropertyName == columnName);

                OnErrorChanged?.Invoke(this, EventArgs.Empty);

                if (error != null)
                {
                    return _validator != null ? error.ErrorMessage : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string Error
        {
            get
            {
                if (_validator != null)
                {
                    var results = _validator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public event EventHandler OnErrorChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract object Clone();

        public abstract void CopyFrom(IBaseEntityViewModel viewModel);
    }
}
