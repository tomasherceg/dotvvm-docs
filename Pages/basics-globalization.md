Several things in DotVVM, like number and date formatting and the resource localization, depend on the current culture.

When DotVVM serializes the viewmodel in the page, it includes the current thread culture which is used on the server to process the request.
If you use any control which works with numberic or date values (e.g. [Literal](/docs/controls/builtin/Literal)), or when you use the
`{resource: ...}` binding, the page needs to know which culture should be used.

In the DotVVM configuration, you can specify the default culture which will be used in all requests. The best way is to set this value 
in the **Startup.cs** using the following code:

```CSHARP
dotvvmConfiguration.DefaultCulture = "en-US";
```

If your website supports multiple languages and cultures, you need to store the language the user has selected somewhere. 
Whichever method you use (cookies, URL, database...), you need to tell DotVVM which culture is being used for the particular HTTP request.
This is done by calling `Context.ChangeCurrentCulture` method. We recommend to call it in the **Init** method in the viewmodel.

```CSHARP
public override Task Init()
{
    var lang = Context.Query["lang"];
    if (lang == "cs")
    {
        Context.ChangeCurrentCulture("cs-CZ");
    }
    else
    {
        Context.ChangeCurrentCulture("en-US");
    }
    return base.Init();
}
```