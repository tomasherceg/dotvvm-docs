## Single Page Applications (SPA)

**DotVVM** supports single page applications (SPA) with minimum effort. It integrates with the master pages mechanism pretty well and 
the only thing you have to do is to replace the [ContentPlaceHolder](/docs/controls/builtin/ContentPlaceHolder/{branch}) with the 
[SpaContentPlaceHolder](/docs/controls/builtin/SpaContentPlaceHolder/{branch}). The content pages will load asynchronously and the 
URL of the current page will be persisted using the URL fragment (e.g. http://myapp.local/#ContentPage1).

To navigate between the pages in the SPA, we recommend to use the [RouteLink](/docs/controls/builtin/RouteLink/{branch}) control. It composes the correct URLs
with support of route parameters. Actually, we recommend to use the [RouteLink](/docs/controls/builtin/RouteLink/{branch})s everywhere, even if you are not using SPAs. 

Let's have the following route registrations in the `DotvvmStartup.cs` file:

```CSHARP
config.RouteTable.Add("ArticleDetail", "Article/{Id}/{Title}", "article.dothtml");;
```

The `RouteLink` control is used this way:

```DOTHTML
<dot:RouteLink RouteName="ArticleDetail" Param-Id="{value: CurrentArticleId}" Param-Title="{value: CurrentArticleTitle}" />
```

The route parameters are specified with attributes prefixed by `Param-`. These won't appear in the page HTML but they will be substituted in the route URL.
If the parameter is not specified here and the current page has a parameter with the same name, the value from the current page will be used. 

If the current page doesn't have this parameter, the default value from the route is used. If it is not specified, an empty string will be substituted for this parameter.

If you need to redirect to another page inside the SPA from the viewmodel command, you can call `Context.RedirectToUrl("url")` or 
`Context.RedirectToRoute("routeName", new { Param1 = param... })`, like in a non-SPA application. SPA will handle this automatically.

### Restrictions

There can be only one [SpaContentPlaceHolder](/docs/controls/builtin/SpaContentPlaceHolder/{branch}) in the page, otherwise the framework wouldn't be able to remember
the URL of currently loaded page in the URL fragment.