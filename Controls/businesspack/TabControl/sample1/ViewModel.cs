using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TabControl.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", Cities = new List<string> { "Praha", "Brno" } },
            new Country { Id = 2, Name = "Slovakia", Cities = new List<string> { "Bratislava", "Košice" } },
            new Country { Id = 3, Name = "United States", Cities = new List<string> { "Washington", "New York" } }
        };
    }
}