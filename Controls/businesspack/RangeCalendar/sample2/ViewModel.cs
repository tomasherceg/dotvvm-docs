using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeCalendar.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-1);
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public DateTime MinimumDate { get; set; } = DateTime.Now.AddDays(-5);
        public DateTime MaximumDate { get; set; } = DateTime.Now.AddDays(5);
    }
}