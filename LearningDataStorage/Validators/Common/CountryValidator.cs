using FluentValidation;

namespace LearningDataStorage
{
    public class CountryValidator : AbstractValidator<CountryViewModel>
    {
        public CountryValidator()
        {
            RuleFor(country => country.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            
            RuleFor(country => country.Alpha3Code)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3);
        }
    }
}
