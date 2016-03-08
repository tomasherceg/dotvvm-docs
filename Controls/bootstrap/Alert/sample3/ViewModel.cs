using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Hosting;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample3
{
    public class ViewModel : MyViewModelBase
    {
        
        public void DoSomething()
        {
            ExecuteWithAlert(() =>
            {
                // the action
            });
        }
    }
    
}