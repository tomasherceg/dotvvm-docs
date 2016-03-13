Hyperlink which builds the URL from route name and parameter values.

The control has **dynamic parameters**. If you want to supply a value of the route parameter called "Id", use the `Param-Id` dynamic property.

The [route configuration](/docs/tutorials/basics-routing/{branch}) is in the `DotvvmStartup.cs` file.

The **RouteLink** can detect whether the page runs inside the SPA container and generate the correct URL.