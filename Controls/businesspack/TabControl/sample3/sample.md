## Sample 3: Alternative Tab Switching

If you don't want to use the `ActiveTabKey` property to identify the tab which is selected, there is an alternative way. 

In the data-bound tabs mode, you can use the `TabIsActiveBinding` property. This property is bound to a `bool` property in each of the `DataSource` collection items, and it will keep track of whether the tab is selected or not.
