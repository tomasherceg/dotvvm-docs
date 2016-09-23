using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DateTimePickerGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; } = new DateTime(1993, 10, 7, 10, 30, 0);
    }
}
