using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public class Country
    {
        public Country()
        {
        }

        public Country(int id, string name, string alpha3Code)
        {
            Id = id;
            Name = name;
            Alpha3Code = alpha3Code;
            Cities = new List<City>();
        }

        public Country(string name, string alpha3Code)
        {
            Name = name;
            Alpha3Code = alpha3Code;
            Cities = new List<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alpha3Code { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
