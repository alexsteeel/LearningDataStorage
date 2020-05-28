using FluentValidation;

namespace LearningDataStorage
{
    public class CityValidator : AbstractValidator<CityViewModel>
    {
        public CityValidator()
        {
            RuleFor(city => city.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(city => city.Country)
                .NotNull();
        }
    }
}
