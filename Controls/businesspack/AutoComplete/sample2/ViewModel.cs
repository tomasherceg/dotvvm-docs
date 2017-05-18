using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample2
{
    public class ViewModel
    {
        public string City1 { get; set; }
        public string City2 { get; set; }

        public int City1ChangeCount { get; set; }
        public int City2ChangeCount { get; set; }

        public IEnumerable<string> Suggestions { get; set; } = new List<string> {
            "Atlantic City",
            "Boston",
            "Chicago",
            "Dalas",
            "New York",
            "Washington D.C.",
            "Miami",
            "San Francisco"
        };

        public void City1Changed() => City1ChangeCount++;
        public void City2Changed() => City2ChangeCount++;
    }
}