using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.InputGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }
        public int Clicks { get; set; } = 0;
        

        public void UpdateText()
        {
            Clicks++;
            Text = "Button was clicked " + Clicks + 'x';
        }

        public string Text2 { get; set; }
        public bool Checked { get; set; }

        public void UpdateText2()
        {
            Text2 = "Checkbox was " + (Checked ? "checked" : "unchecked");
        }
    }
}