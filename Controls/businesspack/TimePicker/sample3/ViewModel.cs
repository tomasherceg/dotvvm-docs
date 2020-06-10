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
            //This will prevent selection of any time between 11:45:00 to 13:14:59
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    11, 45, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    13, 15, 0)
            },
            //This will prevent selection of any time between 16:30:00 to 17:29:59
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    16, 30, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    17, 30, 0)
            }
        };
    }
}
