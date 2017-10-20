using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string City { get; set; }

        public IEnumerable<string> Suggestions { get; set; } = new List<string> {
            "Atlantic City",
            "Boston",
            "Chicago",
            "Dallas",
            "New York",
            "Washington D.C.",
            "Miami",
            "San Francisco"
        };
    }
}