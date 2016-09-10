using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ModalDialog.sample2
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = false;

        public void OpenDialog() 
        {
            Displayed = true;
        }
    }
}