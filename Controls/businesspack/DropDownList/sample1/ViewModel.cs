using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DropDownList.sample1
{
    public class ViewModel
    {
        public string SelectedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}