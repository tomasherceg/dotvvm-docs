using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Salt Lake City", Country = "Utah" },
            new City { Id = 2, Name = "Wichita", Country = "Kansas" },
            new City { Id = 3, Name = "Atlanta", Country = "Georgia" }
        };

        public List<City> SelectedCities { get; set; } = new List<City>();
    }
}