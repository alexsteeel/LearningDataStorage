namespace LearningDataStorage
{
    public class LanguageViewModel : BaseEntityViewModel
    {
        public LanguageViewModel() : base(new LanguageValidator())
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ISO639Code { get; set; }

        public override object Clone()
        {
            return new LanguageViewModel
            {
                Id = this.Id,
                Name = this.Name,
                ISO639Code = this.ISO639Code
            };
        }

        public override void CopyFrom(IBaseEntityViewModel viewModel)
        {
            if (viewModel is LanguageViewModel language)
            {
                Name = language.Name;
                ISO639Code = language.ISO639Code;
            }
        }
    }
}
