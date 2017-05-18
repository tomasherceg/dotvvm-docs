using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample6
{
    public class ViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", IsChecked = true },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<Country> SelectedCountries { get; set; } = new List<Country>();
    }
}