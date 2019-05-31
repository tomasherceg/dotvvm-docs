using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Country { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Atlantic City" },
            new Country { Id = 2, Name = "Boston" },
            new Country { Id = 3, Name = "Chicago"},
            new Country { Id = 4, Name = "Dallas"},
            new Country { Id = 5, Name = "New York"},
            new Country { Id = 6, Name = "Washington D.C."},
            new Country { Id = 7, Name = "Miami"},
            new Country { Id = 8, Name = "San Francisco"}
        };
    }
}