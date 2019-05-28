using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public DateTime MinimumDate { get; set; } = DateTime.Now.AddDays(-5);
        public DateTime MaximumDate { get; set; } = DateTime.Now.AddDays(5);
    }
}