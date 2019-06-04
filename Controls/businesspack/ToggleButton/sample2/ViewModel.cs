using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ToggleButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked { get; set; }
        public int ClickCount { get; set; }
    }
}