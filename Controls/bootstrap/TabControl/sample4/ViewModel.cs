using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TabControl.sample3
{
    public class ViewModel
    { 
        public int CountOfChanges { get; set; } = 0;   
                 
        public void SelectedTabChanged()
        {
            CountOfChanges++;
        }
    }
}