using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample3
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}