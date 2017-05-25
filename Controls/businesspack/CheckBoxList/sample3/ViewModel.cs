using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample3
{
    public class ViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<int> SelectedCountryIds { get; set; } = new List<int>();
    }
}