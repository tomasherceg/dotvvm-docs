using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample2
{
    public class ViewModel
    {
		public string Text { get; set; }	
        public bool IsValid { get; set; }		
		public Dictionary<char, MaskDefinitionItem> AdditionalDefinitions { get; set; }
			= new Dictionary<char, MaskDefinitionItem> {
				{ '1', new MaskDefinitionItem("[0-1]", new Regex("[0-1]")) },
				{ '2', new MaskDefinitionItem(@"\d", new Regex(@"\d")) }
		};		
    }
}