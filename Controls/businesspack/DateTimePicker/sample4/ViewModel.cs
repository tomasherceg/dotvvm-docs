using System;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample4
{
    public class ViewModel
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