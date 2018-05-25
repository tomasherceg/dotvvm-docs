using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Praha", Country = "Czech Republic" },
            new City { Id = 2, Name = "Praha", Country = "Slovakia" },
            new City { Id = 3, Name = "Praha", Country = "Texas" }
        };

        public City SelectedCity { get; set; }
    }
}