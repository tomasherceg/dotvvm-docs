## Single Page Applications (SPA)

**DotVVM** supports single page applications (SPA) with minimum effort. It integrates with master pages concept pretty well and 
the only thing you have to do is to replace `<dot:ContentPlaceHolder>` with `<dot:SpaContentPlaceHolder>`. The content pages will 
load asynchronously and the current URL will be kept in the URL hash (e.g. http://myapp.local/#/ContentPage1).

To be able to navigate in the SPA, you have to use the `<dot:RouteLink>` control. It renders a hyperlink that can load another 
page in the SPA container and works well with URL routing.

Consider following route registrations in the `Startup.cs` file:
```CSHARP

dotvvmConfiguration.RouteTable.Add("ArticleDetail", "Article/{Id}/{Title}", "article.dothtml");
```

The RouteLink control is used this way:
```DOTHTML
<dot:RouteLink RouteName="ArticleDetail" Param-Id="{value: CurrentArticleId}" Param-Title="{value: CurrentArticleTitle}" />
```
The route parameters are specified with attributes prefixed by **Param-**. These won't appear in the page HTML but they will be substituted in the route URL.
If the parameter is not specified here and the current page has a parameter with the same name, the value from the current page will be used. If the current page doesn't have this parameter, the default value from the route is used. If it is not specified, an empty string will be substituted for this parameter.


If you need to redirect to another page inside the SPA from the viewmodel command, you can call `Context.Redirect("url")`. 
SPA will handle this automatically.