using LearningDataStorage.Core.Models;
using System.Collections.Generic;

namespace LearningDataStorage
{
    public class CountryViewModel : BaseEntityViewModel
    {
        public CountryViewModel() : base(new CountryValidator())
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Alpha3Code { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public override object Clone()
        {
            return new CountryViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Alpha3Code = this.Alpha3Code
            };
        }

        public override void CopyFrom(IBaseEntityViewModel viewModel)
        {
            var country = viewModel as CountryViewModel;
            if (country != null)
            {
                Name = country.Name;
                Alpha3Code = country.Alpha3Code;
                Cities = country.Cities;
            }
        }
    }
}
