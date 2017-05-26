### Sample 3: Alternative Tab Switching

If you don't want to use the `ActiveTabIndex` property to identify the tab which is selected, there is an alternative way. 

In the data-bound tabs mode, you can use the `ItemIsActiveBinding` property. This property is bound to a `bool` property in the `DataSource` collection objects which keeps track of whether the tab is selected or not.
