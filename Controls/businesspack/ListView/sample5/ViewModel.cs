using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample5
{
    public class ViewModel
    {
        public string Summary { get; set; }

        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Prague", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" }
        };

        public List<int> SelectedCityIds { get; set; } = new List<int>();

        public void SelectionChanged()
        {
            Summary = string.Join(", ", SelectedCityIds.Select(c => c.ToString()));
        }
    }
}