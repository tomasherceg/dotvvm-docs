using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CountryChangeCount { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }

        public void SelectionChanged()
        {
            CountryChangeCount++;
        }
    }
}