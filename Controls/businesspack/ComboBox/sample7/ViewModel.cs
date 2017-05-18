using System.Collections;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample7
{
    public class ViewModel
    {
        public string Text { get; set; }
        public string SelectedCountry { get; set; }
        public List<string> Countries { get; set; } = new List<string>();

        [AllowStaticCommand]
        public IEnumerable LoadCountries(string searchText)
        {
            return new List<string> {
                $"{searchText} 1", $"{searchText} 2", $"{searchText} 3"
            };
        }
    }
}