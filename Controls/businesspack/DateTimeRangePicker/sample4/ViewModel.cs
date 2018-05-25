using System;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimeRangePicker.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-1);
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        public List<CalendarRestrictionBase> Restrictions { get; set; } = new List<CalendarRestrictionBase>()
        {
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Saturday },
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Sunday },
            new DateRangeRestriction() { StartDate = DateTime.MinValue, EndDate = DateTime.Now }
        };
    }
}