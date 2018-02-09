using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample3
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