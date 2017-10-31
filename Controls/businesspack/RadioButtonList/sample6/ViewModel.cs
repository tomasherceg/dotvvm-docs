using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsControlEnabled { get; set; }
        public bool IsItemEnabled { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States", IsEnabled = false }
        };

        public Country SelectedCountry { get; set; }
    }
}