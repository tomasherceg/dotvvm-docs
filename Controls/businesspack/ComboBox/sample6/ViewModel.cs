using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCountry { get; set; }

        public string TypedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}