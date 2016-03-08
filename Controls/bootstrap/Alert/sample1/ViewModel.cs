using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample2
{
    public class ViewModel
    {
        public void Dismiss()
        {
            Dismissed = !Dismissed;
        }

        public bool Dismissed { get; set; } = false;
    }
}