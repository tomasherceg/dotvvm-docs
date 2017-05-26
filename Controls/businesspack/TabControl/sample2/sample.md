### Sample 2: Tab Index

The `ActiveTabIndex` property specifies an index of the tab which is currently selected. The data-binding works in both ways, so it is possible to switch the tabs from the viewmodel.

The `ActiveTabChanged` property specifies a command in the viewmodel which is triggered when the user switches the tab.

If the tab header contains only a text value, you can use the `HeaderText` property instead of the `HeaderTemplate`.
