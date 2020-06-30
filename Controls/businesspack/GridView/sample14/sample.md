## Sample 14: Row Selection

`GridView` supports row selection via adding a special column `GridViewRowSelectColumn`. This column will render checkbox in each row, which will allow your users to select rows via ticking this checkbox.

The `SelectedRows` property is bound to the property which contains list of selected rows from the `DataSource` collection. 

To make `SelectedRows` contains only value of a specific property from `DataSource` object (like the `Id` property of the selected objects), you may use the `ItemValueBinding` property.