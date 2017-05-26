using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample3
{
    public class ViewModel
    {
        public string Text { get; set; } = "";

        public void TextToUpperCase()
        {
            Text = Text.ToUpper();
        }
    }
}