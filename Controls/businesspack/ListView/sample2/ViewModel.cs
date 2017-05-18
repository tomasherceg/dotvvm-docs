using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample2
{
    public class ViewModel
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