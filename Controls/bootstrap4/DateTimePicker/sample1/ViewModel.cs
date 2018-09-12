using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DateTimePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; }

        public ViewModel()
        {
            Date = DateTime.Now;
        }
    }
}
