## Adding DotVVM in Existing Web App

**DotVVM** can be easily combined with other ASP.NET frameworks, like SignalR, Web API or MVC. 
DotVVM is yet another OWIN / ASP.NET Core middleware that can be added in the request processing pipeline.


### Installing the Nuget Package (OWIN)

If you use classic .NET Framework project, you are most probably using **OWIN** to compose your web application.

To add **DotVVM** in an existing ASP.NET project with OWIN, simply install `DotVVM.Owin` Nuget package using Package Manager Console:

    Install-Package DotVVM.Owin -Pre

The package will reference **DotVVM.Framework** and **DotVVM.Framework.Hosting.Owin** libraries in the project.


### Initialization

The next thing you have to do, is to register the DotVVM middleware. In your Owin startup class, you have to add the 
DotVVM middleware. If you are using some authentication middlewares, remember that these should be registered first.

If you don't have an Owin startup class in your projects, right click the project in the Solution Explorer window and 
add new _OWIN Startup Class_ in the project. It should look like this. 

```CSHARP
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;
using DotVVM.Framework;
    
[assembly: OwinStartup(typeof(DotvvmDemo.Startup))]
namespace DotvvmDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // initialize DotVVM
            var applicationPhysicalPath = HostingEnvironment.ApplicationPhysicalPath;
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(applicationPhysicalPath);    
        }
    }
}
```

<br />


### Installing the Nuget Package (ASP.NET Core)

If you use .NET Core, or the new ASP.NET Core stack, you need ASP.NET Core version of DotVVM.

To add **DotVVM** in an existing ASP.NET Core project, simply install `DotVVM.AspNetCore` Nuget package using Package Manager Console:

    Install-Package DotVVM.AspNetCore -Pre

The package will reference **DotVVM.Framework** and **DotVVM.Framework.Hosting.AspNetCore** libraries in the project.


### Initialization

You have to do two things in the `Startup` class:

* Add DotVVM services in the `IServiceCollection` object.

* Add the DotVVM middlewares in the ASP.NET Core request pipeline.

First, add the following code snippet in the `ConfigureServices` method:

```CSHARP
services.AddDotVVM(options =>
{
    options.AddDefaultTempStorages("Temp");
});
```

Second, add the following code snippet in the `Configure` method. If you are using some authentication middlewares, remember that these should be registered first.

```CSHARP
var config = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
```



### DotvvmStartup class (both OWIN and ASP.NET Core)

Notice that the code references the `DotvvmStartup` class. It is a class you have to add in your project too. 
This class contains the configuration of DotVVM itself, e.g. the registration of routes in your app.

```CSHARP
using DotVVM.Framework.Compilation.Parser;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;

namespace DotvvmDemo
{
    public class DotvvmStartup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
#if DEBUG
            config.Debug = true;
#endif

            // register your routes, controls and resources here
        }        
    }
}
```
