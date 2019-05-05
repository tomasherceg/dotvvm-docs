## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. For each item in the collection, a checkbox will be created.

The `SelectedValues` property is bound to a collection which contains all values of checkboxes that are checked. The data-binding works in both ways, so you can either read, or modify the collection in the viewmodel and the checkbox states will be synchronized to reflect changes made to the collection.
