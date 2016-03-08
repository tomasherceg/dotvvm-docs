### Sample 6: ResponsiveNavigation with items loaded from data source

The ResponsiveNavigation has several properties which you can use to load items from ViewModel.

To load items from collection, use `DataSource` property.  
Source of displayed must be configured in `TextBinding` *string* propery.  
Source of item url must be set in `NavigateUrlBinding` property.  
When you want to control enabled status of items loaded form DataSource you can do so by  `IsDisabledBinding` *bool* property.
To style loaded items as selected use `IsSelectedBinding` *bool* property.