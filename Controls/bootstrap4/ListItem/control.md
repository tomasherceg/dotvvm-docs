A base class representing an item in Bootstrap lists and menus. This list item is used in the following controls:

* [Breadcrumb](/docs/controls/bootstrap4/Breadcrumb/{branch}) uses `<bs:BreadcrumbItem>`.
* [DropDownButton](/docs/controls/bootstrap4/DropDownButton/{branch}) uses `<bs:DropDownButtonItem>`.
* [ListGroup](/docs/controls/bootstrap4/ListGroup/{branch}) uses `<bs:ListGroupItem>`.
* [NavigationBar](/docs/controls/bootstrap4/NavigationBar/{branch}) uses `<bs:NavigationItem>`.
* [ResponsiveNavigation](/docs/controls/bootstrap4/ResponsiveNavigation/{branch}) uses `<bs:NavigationItem>`.

All these controls use the following properties on its list items:

* `Text` represents the text on the list item. Alternatively, you can use `ContentTemplate` property to specify any HTML content. 
* If you set the `NavigateUrl` property, or you use the `RouteName`, `Param-*`, `Query-*` and `UrlSuffix` properties, the item will behave like a hyperlink. For more information about `RouteName` properties, see [RouteLink](/docs/controls/builtin/RouteLink/{branch}) control.
* Alternatively, you can set the `Click` command which specifies the  method in the viewmodel to be triggered. 
* `Enabled` property can be used to enable or disable the list item. 
* `IsSelected` property specifies whether the list item is active or not.