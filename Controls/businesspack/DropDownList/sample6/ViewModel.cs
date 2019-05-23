using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DropDownList.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Praha", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" },
            new City { Id = 3, Name = "Austin", Country = "Texas" }
        };

        public City SelectedCity { get; set; }
    }
}