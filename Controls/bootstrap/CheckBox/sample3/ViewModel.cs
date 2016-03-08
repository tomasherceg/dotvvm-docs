using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CheckBox.sample3
{
    public class ViewModel
    {
        public string SelectedColors { get; set; }

        public List<string> Colors { get; set; } = new List<string>() {"r", "g"};

        public ViewModel()
        {
            UpdateSelectedColors();
        }

        public void UpdateSelectedColors()
        {
            SelectedColors = string.Join(", ", Colors.Select(i => i.ToString()));
        }
    }
}