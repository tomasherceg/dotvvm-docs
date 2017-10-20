using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }


        public List<string> FavoriteColors { get; set; } = new List<string> {
            "red", "green", "blue", "yellow", "white", "black"
        };

        public string SelectedColor { get; set; }
    }
}