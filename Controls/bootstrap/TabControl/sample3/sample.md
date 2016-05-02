### Sample 3: TabControl DataSource

To load items from collection, use `DataSource` property binded on IEnumerable of any objects.
`HeaderTemplate` and `ContentTemplate` determines templates for generated tabs, which automatically uses bindings directly from objects in `DataSource` as shown in example.
  
When you want to control whether tab is active on tabs loaded form `DataSource` you can do so by  `IsActiveBinding` property which should point to property in `DataSource` objects which represents `IsActive` property of tabs.