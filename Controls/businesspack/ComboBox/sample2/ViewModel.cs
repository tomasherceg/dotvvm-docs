using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample2
{
    public class ViewModel
    {
        public Country SelectedCountry { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };
    }
}