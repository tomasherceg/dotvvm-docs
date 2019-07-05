using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public List<DateRestriction> Restrictions { get; set; } = new List<DateRestriction>()
        {
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Saturday },
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Sunday },
            new DateRangeRestriction() { StartDate = DateTime.MinValue, EndDate = DateTime.Now }
        };
    }
}
