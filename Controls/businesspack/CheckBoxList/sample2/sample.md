## Sample 2: Working with Objects

When the `DataSource` collection is bound to a collection of objects, you may use the `ItemTextBinding` to specify, which property of the object in the collection will be displayed as a text of a particular checkbox control.

The `SelectedValues` will contain the objects from the `DataSource` collection which are checked. 

In order to allow the control to uniquely identify these objects, you need to use the `ItemKeyBinding` property to define a property which can work as a key. The key must be unique for all items in the collection, otherwise the control will not work properly.