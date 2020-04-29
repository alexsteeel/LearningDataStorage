using FluentValidation;

namespace LearningDataStorage.Core.Models
{
    public class CityValidator : AbstractValidator<CityViewModel>
    {
        public CityValidator()
        {
            RuleFor(city => city.Id).NotNull();
            RuleFor(city => city.Name).NotNull().NotEmpty();
            RuleFor(city => city.Country).NotNull();
        }
    }
}
