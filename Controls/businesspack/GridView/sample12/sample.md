## Sample 12: Filtering

By default, filtering is not enabled on any column.

The filtering option can be turned on using the `AllowFiltering` property.

To customize where the filters appear, you can use the `FilterPlacement` property with values `Popup`, `HeaderRow`, `SeparateHeaderRow` and `SeparateFooterRow`. The default value is `Popup`.

If you want to define your custom template for filtering, you can specify the `FilterTemplate` inner element to provide a custom filter UI on every column. Even if the `FilterTemplate` is provided, it's still necessary set `AllowFiltering` to `true`.

In the viewmodel class, you can access filters by `FilteringOptions` property on your `BusinessPackDataSet` object. This property stores all currently used filters on `GridView`.

The `LoadFromQueryable` method will apply the filters on the `IQueryable` automatically. If you load the dataset with your own logic, you'll need to inspect the `FilteringOptions` and build the query appropriately. 
