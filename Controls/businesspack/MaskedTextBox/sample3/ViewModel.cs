using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public Dictionary<char, MaskPattern> Patterns { get; set; } = new Dictionary<char, MaskPattern> {
            { 'c', new MaskPattern(@"\w") },
            { 'n', new MaskPattern(@"\d") }
        };
    }
}