using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample2
{
    public class ViewModel
    {
        public string City { get; set; }

        public int CityChangeCount { get; set; }

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

        public void CityChanged() => CityChangeCount++;
    }
}