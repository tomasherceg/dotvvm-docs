using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public int DateSelectionsCount { get; set; }

        public void SelectionCompleted()
        {
            DateSelectionsCount++;
        }
    }
}