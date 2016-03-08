using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "";

        public void TextToUpperCase()
        {
            Text = Text.ToUpper();
        }
    }
}
