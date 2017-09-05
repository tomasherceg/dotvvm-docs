using System.Collections;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample7
{
    public class ViewModel
    {
        public string Text { get; set; }

        public Country SelectedCountry { get; set; }

        public List<Country> Countries { get; set; } = new List<Country>();

        [AllowStaticCommand]
        public IEnumerable<Country> LoadCountries(string searchText)
        {
            yield return new Country {
                Name = searchText
            }
        }
    }
}