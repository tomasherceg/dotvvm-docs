using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Bannana",
            "Orange",
            "Watermeloon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();
    }
}