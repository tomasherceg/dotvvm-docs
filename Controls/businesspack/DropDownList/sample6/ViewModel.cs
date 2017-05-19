using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DropDownList.sample6
{
    public class ViewModel
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Washington", Country = "Utah" },
            new City { Id = 2, Name = "Washington", Country = "Kansas" },
            new City { Id = 3, Name = "Washington", Country = "Georgia" }
        };

        public City SelectedCity { get; set; }
    }
}