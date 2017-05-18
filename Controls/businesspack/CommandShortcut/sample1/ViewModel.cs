using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CommandShortcut.sample1
{
    public class ViewModel
    {
        public string LastSave { get; set; } = "Not saved yet.";

        public void Save()
        {
            LastSave = DateTime.Now.ToString("HH:MM:ss");
        }
    }
}