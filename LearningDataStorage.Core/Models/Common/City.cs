namespace LearningDataStorage.Core.Models
{
    public class City
    {
        public City()
        {
        }

        public City(int id, string name, int countryId)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
        }

        public City(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }


        public int Id { get; set; }
        
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
