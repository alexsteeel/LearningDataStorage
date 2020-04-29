using FluentValidation;

namespace LearningDataStorage.Core.Models
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(language => language.Id).NotNull();
            RuleFor(language => language.Name).NotNull();
            RuleFor(language => language.ISO639Code).NotNull();
        }
    }
}
