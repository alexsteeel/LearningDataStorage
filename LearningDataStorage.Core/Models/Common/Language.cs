namespace LearningDataStorage.Core.Models
{
    public class Language
    {
        public Language()
        {
        }

        public Language(int id, string name, string iso639Code)
        {
            Id = id;
            Name = name;
            ISO639Code = iso639Code;
        }

        public Language(string name, string iso639Code)
        {
            Name = name;
            ISO639Code = iso639Code;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ISO639Code { get; set; }
    }
}
