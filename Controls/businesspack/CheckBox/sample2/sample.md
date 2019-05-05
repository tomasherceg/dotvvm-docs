## Sample 2: Multiple CheckBoxes

The CheckBox has also a property `CheckedItems` which can bind to any collection. This is an alternative to the `Checked` property - these properties cannot be combined.
The collection will always contain values of the checkboxes which are checked. The value of the checkbox which should be inserted in the collection, is defined in the `CheckedValue` property.

The first two checkboxes will be checked when the page loads, because the collection contains initial values "r" and "g".
If you uncheck or check a checkbox, the collection will be updated immediately.

You can also modify the collection contents in the viewmodel code which will update the checkbox check states appropriately.
