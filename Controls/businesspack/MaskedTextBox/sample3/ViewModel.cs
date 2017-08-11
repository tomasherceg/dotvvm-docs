using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample3
{
    public class ViewModel
    {
		public string Text { get; set; }	
        public bool IsValid { get; set; }		
		public Dictionary<char, MaskDefinitionItem> Definitions { get; set; }
			= new Dictionary<char, MaskDefinitionItem> {
				{ 'c', new MaskDefinitionItem(@"\w", new Regex(@"\w")) },
				{ 'n', new MaskDefinitionItem(@"\d", new Regex(@"\d")) }
		};	
    }
}