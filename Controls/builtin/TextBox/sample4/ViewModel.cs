using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCompany { get; set; }

        public string CompanyNumber { get; set; } = "";
        
    }
}
