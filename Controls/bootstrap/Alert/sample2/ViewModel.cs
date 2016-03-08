using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Hosting;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Dismissed { get; set; } = false;
        public string Text { get; set; }

        public void AlertDismissed()
        {
            Text = "Alert was hidden.";
        }

        public void Dismiss()
        {
            Dismissed = !Dismissed;
        }
    }
    
}