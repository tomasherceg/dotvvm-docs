## Sample 3: Restrictions

If you require more granular control over what dates can be selected, you can use the `Restrictions` property.

- **TimeRangeRestriction** - Allows to disable selection of a specific time range. You just need to set the `StartTime` and `EndTime` properties, where the `StartTime` represents inclusive start of the restriction and `EndTime` represents end of the restriction. Date part of the `DateTime` values is ignored so any date can be provided.
