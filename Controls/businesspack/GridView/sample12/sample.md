## Sample 12: Filtering

By default, the filtering is not enabled on any column.

The filtering option is customizable per every column by `AllowFiltering` property which turns filtering on and off.

To customize filters, you can use `FilterPlacement` property with values `Popup`, `HeaderRow`, `SeparateHeaderRow` and `SeparateFooterRow`. The default value is `Popup`.

If you need to use some custom logic for filtering, you can specify the `FilterTemplate` to provide a custom filter template on every column. 
Even if the `FilterTemplate` is provided it's still necessary set `AllowFiltering` to `true`.

In the `ViewModel` class, you can access filters by `FilteringOptions` property on your `BusinessPackDataSet` object. This property stores all currently used filters on `GridView`.