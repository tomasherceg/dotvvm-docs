using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CollapsiblePanel.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Collapsed1 { get; set; }

        public bool Collapsed2 { get; set; }

        public void CollapseAll()
        {
            Collapsed1 = true;
            Collapsed2 = true;
        }
    }
}