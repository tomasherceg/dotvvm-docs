using System;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Calendar.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public List<CalendarRestrictionBase> Restrictions { get; set; } = new List<CalendarRestrictionBase>()
        {
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Saturday },
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Sunday },
            new DateRangeRestriction() { StartDate = DateTime.MinValue, EndDate = DateTime.Now }
        };
    }
}