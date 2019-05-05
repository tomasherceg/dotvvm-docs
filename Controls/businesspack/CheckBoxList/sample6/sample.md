## Sample 6: In-place Checked Property

If you do not need to have a second collection with the items that are checked, you can make the control to store the state of the individual items in the items of the `DataSource` collection. 

Let's assume that the `DataSource` collection items have the `IsChecked` property. We can have this property set to `true` or `false` based on the checkbox state, using the `ItemCheckedBinding` property.
