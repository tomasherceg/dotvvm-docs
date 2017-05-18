using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample2
{
    public class ViewModel
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public DateTime MinimumDate { get; set; } = DateTime.Now.AddDays(-5);
        public DateTime MaximumDate { get; set; } = DateTime.Now.AddDays(5);
    }
}