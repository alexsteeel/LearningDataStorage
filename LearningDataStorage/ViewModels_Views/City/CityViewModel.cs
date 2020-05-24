using LearningDataStorage.Core.Models;

namespace LearningDataStorage
{
    public class CityViewModel : BaseEntityViewModel
    {
        public CityViewModel() : base(new CityValidator())
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
