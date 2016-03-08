using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample3
{
    public class ViewModel
    {
        public bool Value { get; set; }

        public int NumberOfChanges { get; set; } = 0;

        public void OnChanged()
        {
            NumberOfChanges++;
        }

    }
}