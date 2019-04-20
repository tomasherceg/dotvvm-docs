## Sample 3: Data-binding

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `TextBinding` specifies the property of the collection elements to be used as list item text.
* `ColorBinding` specifies the property of the collection elements to be used as list item color.
* `NavigateUrlBinding` specifies the property of the collection elements to be used as list item link URL.
* `IsEnabledBinding` specifies the property of the collection elements indicating whether the list item is enabled or not.
* `IsSelectedBinding` specifies the property of the collection elements indicating whether the list item is active or not.
* `ClickBinding` specifies a command in the viewmodel to be called when the list item is clicked.