using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.SwitchButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked { get; set; }
        public int ClickCount { get; set; }
    }
}