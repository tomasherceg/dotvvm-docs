using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample4
{
    public class ViewModel
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Prague", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" }
        };

        public List<City> SelectedCities { get; set; } = new List<City>();
    }
}