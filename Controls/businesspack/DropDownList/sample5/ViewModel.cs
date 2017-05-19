using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DropDownList.sample5
{
    public class ViewModel
    {
        public Country SelectedCountry { get; set; }
        public string SelectedCity { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", Cities = new List<string> { "Praha", "Brno" } },
            new Country { Id = 2, Name = "Slovakia", Cities = new List<string> { "Bratislava", "Košice" } },
            new Country { Id = 3, Name = "United States", Cities = new List<string> { "Washington", "New York" } }
        };

        public List<string> Cities { get; set; } = new List<string>();

        public void CountryChanged()
        {
            SelectedCity = null;
            Cities = SelectedCountry.Cities;
        }
    }
}