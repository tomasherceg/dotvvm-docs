## Upgrading from DotVVM 1.0

Because **DotVVM 1.1** brought support for ASP.NET Core, we had to do many fundamental changes inside the framework, and there are several breaking changes.

If your app is built on **DotVVM 1.0**, you need to take the foolowing steps to upgrade to **DotVVM 1.1 on OWIN**.



### 1. Install the DotVVM.Owin NuGet Package

In the 1.0 version, the **DotVVM** NuGet package included the framework and the hosting infrastructure together in one library.

In the 1.1 version, we have moved the OWIN hosting infrastructure to a separate package, and that's why you need to add it to your project.



### 2. Change OwinContext to GetOwinContext() or to HttpContext

The `Context` object which is available in the viewmodel, had the `OwinContext` property which could access the information about the current HTTP request
and manipulate with the response.

Because the API changed on ASP.NET Core, we have added the `HttpContext` property which provides a unified API for OWIN and ASP.NET Core. 
However, there are some differences and there are not all features available in the original `OwinContext` property.

If you want to get the real OWIN context, you can call the `GetOwinContext()` extension method and get the same API.



### 3. Change OwinContext.Authentication to GetAuthentication()

The same thing applies to `OwinContext.Authentication` property. You can use the `GetAuthentication()` extension method to get this API quickly.



### 4. Change DotvvmRequestContext to IDotvvmRequestContext in Custom Presenters

In the 1.0 version, the `IDotvvmRequestContext` declared the `ProcessRequest` method with an argument of type `DotvvmRequestContext`, which was wrong.

In the 1.1 version, we fixed this, so the argument is `IDotvvmRequestContext`, which allows to mock the context easily when testing the presenter.


### 5. DefaultViewModelLoader requires IServiceProvider

If you derived from the `DefaultViewModelLoader` class to do the dependency injection in the viewmodels, you need to request the `IServiceProvider` argument
in the constructor of your class, and pass it to the constructor of `DefaultViewModelLoader`. 

```CSHARP
public class WindsorViewModelLoader : DefaultViewModelLoader
{
    private readonly WindsorContainer container;

    public WindsorViewModelLoader(WindsorContainer container, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.container = container;
    }

    ...
}
```


### 6. ServiceLocator changes to IServiceProvider

Since Microsoft has brought their own dependency injection mechanisms in the ASP.NET Core, to make the things unified, we have used this infrastructure 
in DotVVM too.

If you registered custom services in the `DotvvmConfiguration.ServiceLocator`, you have to change the registrations to the following ones:

```CSHARP
var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(applicationPhysicalPath, options: options =>
{
    options.Services.AddSingleton<IViewModelLoader>(serviceProvider => new WindsorViewModelLoader(container, serviceProvider));    
});
```

Also, you can only register services in the `UseDotVVM` method by passing a method to the `options` parameter. 

If you try to add services in the `IServiceProvider` later, it may fail because the object denies changes to its configuration after the first service is resolved.



### 7. Make ActionFilter and ExceptionFilter Methods Async

We needed to change all methods on the `ActionFilterAttribute` and `ExceptionFilterAttribute` to async versions. 

```CSHARP
protected override Task OnCommandExceptionAsync(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception) 
{
    ...
}
```

Also, if you want to intercept only some of the methods, you don't need to derive from the `ActionFilterAttribute`, but you can only implement one of the 
following interfaces:

* `IPageActionFilter` contains page-level events - `OnPageLoadingAsync`, `OnPageLoadedAsync` and `OnPageExceptionAsync`. 

* `ICommandActionFilter` contains command-related events - `OnCommandExecutingAsync` and `OnCommandExecutedAsync`.

* `IViewModelActionFilter` contains viewmodel-related events - `OnViewModelCreatedAsync` and `OnViewModelDeserializedAsync` and `OnViewModelSerializingAsync` (which replaces the `OnResponseRendering`).


### 8. Rename the HideNonAuthenticatedUsers to HideForAnonymousUsers on RoleView

If you are using the `<dot:RoleView>` control, please rename the `HideNonAuthenticatedUsers` to `HideForAnonymousUsers` property which makes better sense.