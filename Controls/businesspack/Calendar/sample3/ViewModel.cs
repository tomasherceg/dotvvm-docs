using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Calendar.sample3
{
    public class ViewModel
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public DateTime SelectedTime { get; set; } = DateTime.Now;
        public DateTime SelectedDateTime { get; set; } = DateTime.Now;
    }
}