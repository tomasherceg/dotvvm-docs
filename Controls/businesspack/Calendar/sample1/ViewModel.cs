using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Calendar.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime ActiveDate { get; set; } = DateTime.Now.AddDays(5);
    }
}