using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;
        public DateTime MinimumTime { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 
            7, 30, 0);
        public DateTime MaximumTime { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 
            19, 30, 0);
    }
}