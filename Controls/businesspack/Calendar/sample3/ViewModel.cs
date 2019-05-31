using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Calendar.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime ActiveDate { get; set; } = DateTime.Now;

        public DateTime NextDay { get; set; } = DateTime.Now.AddDays(1);
    }
}