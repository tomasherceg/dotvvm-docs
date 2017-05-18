using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Calendar.sample5
{
    public class ViewModel
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public int DateSelectionsCount { get; set; }

        public void SelectionCompleted()
        {
            DateSelectionsCount++;
        }
    }
}