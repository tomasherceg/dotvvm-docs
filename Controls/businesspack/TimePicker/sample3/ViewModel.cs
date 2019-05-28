using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;

        public List<TimeRestriction> Restrictions { get; set; } = new List<TimeRestriction>()
        {
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    11, 45, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    13, 15, 0)
            },
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    16, 30, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    17, 30, 0)
            }
        };
    }
}
