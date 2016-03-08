### Sample 3: Items loaded from ViewModel

`NavigationBar `has several properties which you can use to load items directly from ViewModel.
`DataSource` property define binded collection of objects from ViewModel.  

To properly fill properties in `NavigationItems` it is necessary to configure which properties from loaded objects should be used.
For this purpose there are `TextBinding`, `NavigateUrlBinding`, `IsDisabledBinding` and `IsSelectedBinding` properties.