using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample4
{
    public class ViewModel
    {
        public int SelectedCountriesCount { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public List<string> SelectedCountries { get; set; } = new List<string>();

        public void SelectionChanged()
        {
            SelectedCountriesCount = SelectedCountries.Count;
        }
    }
}