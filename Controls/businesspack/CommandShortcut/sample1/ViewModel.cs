using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CommandShortcut.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LastSave { get; set; } = "Not saved yet.";

        public void Save()
        {
            LastSave = DateTime.Now.ToString("HH:MM:ss");
        }
    }
}