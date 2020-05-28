using FluentValidation;
using LearningDataStorage.Core.Models;

namespace LearningDataStorage
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(language => language.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(language => language.ISO639Code)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3);
        }
    }
}
