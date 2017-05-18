using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TabControl.sample3
{
    public class ViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", Cities = new List<string> { "Praha", "Brno" } },
            new Country { Id = 2, Name = "Slovakia", Cities = new List<string> { "Bratislava", "Košice" } }
        };
    }
}