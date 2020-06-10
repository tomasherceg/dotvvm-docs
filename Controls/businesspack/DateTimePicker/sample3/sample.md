## Sample 3: Restrictions

If you require more granular control over what dates can be selected, you can use the `Restrictions` property. We currently support the following types of restrictions:

- **DayOfWeekRestriction** - Allows to disable selection of a specific day of week.
- **DateRangeRestriction** - Allows to disable a secific range of dates (one day, one month, etc.). You just need to set the `StartDate` and `EndDate` properties, where the `StartDate` represents inclusive start of the restriction and `EndDate` represents exclusive end of the restriction. 
- **TimeRangeRestriction** - Allows to disable selection of a specific time range. You just need to set the `StartTime` and `EndTime` properties, where the `StartTime` represents inclusive start of the restriction and `EndTime` represents end of the restriction.

Restrictions can be combined with `MinDateTime` and `MaxDateTime` properties and are verified both on client-side and server-side.