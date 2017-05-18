using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample4
{
    public class ViewModel
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