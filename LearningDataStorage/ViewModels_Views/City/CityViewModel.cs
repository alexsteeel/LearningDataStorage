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

        public Country Country { get; set; }

        public override object Clone()
        {
            return new CityViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Country = this.Country
            };
        }

        public override void CopyFrom(IBaseEntityViewModel viewModel)
        {
            var city = viewModel as CityViewModel;
            if (city != null)
            {
                Name = city.Name;
                Country = city.Country;
            }
        }
    }
}
