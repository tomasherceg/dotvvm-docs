using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;
    }
}