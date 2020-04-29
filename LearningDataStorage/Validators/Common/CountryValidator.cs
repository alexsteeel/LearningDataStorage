using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public class CountryValidator
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alpha3Code { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
