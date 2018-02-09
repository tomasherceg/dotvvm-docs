using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public DateTime SelectedTime { get; set; } = DateTime.Now;
        public DateTime SelectedDateTime { get; set; } = DateTime.Now;
    }
}