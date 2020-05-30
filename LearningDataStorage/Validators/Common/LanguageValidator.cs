using FluentValidation;

namespace LearningDataStorage
{
    public class LanguageValidator : AbstractValidator<LanguageViewModel>
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
