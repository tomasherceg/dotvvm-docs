## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. When the user starts interacting with the control, a list of items made from this collection will appear.

The `SelectedValues` property is bound to a collection which contains all items that are selected. The data-binding works in both ways, so you can either read, or modify the collection in the viewmodel and the selected values in the control will get synchronized to reflect the changes.

The `Placeholder` specifies the text displayed when the `Text` is empty.