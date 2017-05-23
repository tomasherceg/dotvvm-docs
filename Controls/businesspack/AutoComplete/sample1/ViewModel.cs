using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample1
{
    public class ViewModel
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