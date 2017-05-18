using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample1
{
    public class ViewModel
    {
        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }
    }
}