## DotVVM Configuration

Most of the stuff in DotVVM is configured using the C# code. In the default project template, there are 2 files - `Startup.cs` and `DotvvmStartup.cs`. 

### Startup.cs

The `Startup.cs` is the OWIN startup class. DotVVM is just an OWIN middleware and you can easily combine it with ASP.NET MVC or any other OWIN framework.
All you have to do is to register the DotVVM middleware in the `IAppBuilder` object.

```CSHARP
var config = app.UseDotVVM<DotvvmStartup>(ApplicationPhysicalPath);
```

This extension method initializes the DotVVM middleware (actually, we have more than one). The `DotvvmStartup` type parameter represents the class which contains
DotVVM settings. 

This call returns the `DotvvmConfiguration` object, but the configuration of DotVVM should be mostly in the `DotvvmStartup.cs`.

In the default project template, the `Startup` class also registers a static files middleware. DotVVM doesn't need it itself, however in 99% cases you want to use OWIN to serve 
static files like images to the user.

### DotvvmStartup.cs

The `DotvvmStartup` class must implement the `IDotvvmStartup` interface and contains the `Configure` method. In this method you need to configure:

+ **Routes** (see more information in the [Routing](/docs/tutorials/basics-routing/{branch}) chapter)

+ **Custom Resources** (see more in the [Javascript and CSS Resource Management](/docs/tutorials/basics-javascript-and-css/{branch}) chapter)

+ **Custom Controls** (see more in the [Control Development](/docs/tutorials/control-development-introduction/{branch}) chapter)

Please note that the [DotVVM Pro for Visual Studio 2015](/products/dotvvm-pro-for-vs-2015) executes the `Configure` method during the project build process so it can
do IntelliSense for custom controls, route names etc. 

>Avoid registering any other things than routes, custom resources and custom controls in the `Configure` method as it might be executed many times 
>when you have the project open in Visual Studio.

If you need to register or initialize anything else (e.g. initialize the database, create default users), do it in the `Startup.cs` instead.
