using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample3
{
    public class ViewModel
    {
        public int RemainingSelections { get; set; } = 3;

        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Bannana",
            "Orange",
            "Watermeloon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();

        public void SelectionChanged()
        {
            RemainingSelections = 3 - SelectedFruit.Count;
        }
    }
}