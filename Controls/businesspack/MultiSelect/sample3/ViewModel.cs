using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<int> SelectedCountries { get; set; } = new List<int>();
        public string Summary { get; set; }

        public void PrintSummary()
        {
            Summary = string.Join(", ", SelectedCountries.Select(c => c.ToString()));
        }
    }
}