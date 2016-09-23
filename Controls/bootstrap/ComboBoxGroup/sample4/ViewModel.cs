using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedNumber { get; set; }
        public int[] Numbers { get; set; } = { 7, 10, 13, 19 };
        public string Result { get; set; } = "Select something...";

        public void SelectionChanged()
        {
            Result = SelectedNumber != 10 ? "Correct!" : "10 is not a prime number!";
        }
    }
}
