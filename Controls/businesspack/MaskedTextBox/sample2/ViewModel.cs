using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample2
{
    public class ViewModel
    {
        public string Text { get; set; }

        public Dictionary<char, MaskPattern> AdditionalPatterns { get; set; } = new Dictionary<char, MaskPattern> {
            { '1', new MaskPattern("[0-1]") },
            { '2', new MaskPattern(@"\d") }
        };
    }
}