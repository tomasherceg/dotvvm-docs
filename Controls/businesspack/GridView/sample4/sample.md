## Sample 4: Sorting

By default, the sorting is not enabled on any column. You can use the `AllowSorting` property to enable it.

The columns which have the `Value`, will sort using the specified expression by default. If the column doesn't have this property (e. g. `GridViewTemplateColumn`), or if you need to use another property to define the order of the rows, you can use the `SortExpression` property. This property takes precedence over the `Value`.

To customize the icons for sorting, you can use the `SortAscendingHeaderCssClass` and `SortDescendingHeaderCssClass` properties which specify the CSS class to be added to the header of the column which is used for the searching.

You can also set these properties on the `GridView` control instead of declaring them for each column separately, using `GridViewColumn.SortAscendingHeaderCssClass="value"`.
