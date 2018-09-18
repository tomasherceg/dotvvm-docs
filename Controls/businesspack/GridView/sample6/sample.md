## Sample 6: Inline Editing

Enum `InlineEditMode` determines, if it will be enabled the user can edit rows directly in the grid. To enable editing set the value to `SingleRow`.

Every column has the `AllowEditing` property which specifies whether the column can be edited or not.

The columns also have the `EditTemplate` property which can be used to define a custom edit template for the cell.

The object that is currently being edited, is identified by the `Customers.RowEditOptions.EditRowId` property which contains the primary key of the edited object. The name of the property which is a primary key, is stored in `Customers.RowEditOptions.PrimaryKeyPropertyName`.
