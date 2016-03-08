## Add DotVVM to existing app

**DotVVM** can be easily combined with other ASP.NET frameworks, like SignalR, Web API or MVC. 
DotVVM is yet another OWIN middleware that can be inserted into the request processing pipeline.


### Installing the Nuget Package

To add **DotVVM** in an existing ASP.NET project, simply install **DotVVM** Nuget package using Package Manager Console:

    Install-Package DotVVM -Pre

The package will do the following things:

* Add a reference to **DotVVM.Framework** library to the project.

* Generate a **dotvvm.json** configuration file with a new set of security keys.


_The dotvvm.json file contains security keys that are used to protect viewmodels on the client side. 
Please do not copy security keys from one project to another. If you lose or compromise them, 
run `Generate-DotVVMSecurityKeys` in the Package Manager Console to generate a new pair._


### Initialization

The last thing you have to do is to register the DotVVM middleware. Add an _OWIN Startup Class_ in the project
and place the following code snippet into the file:

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
        private WindsorContainer container;
    
        public void Configuration(IAppBuilder app)
        {
            // initialize DotVVM
            var applicationPhysicalPath = HostingEnvironment.ApplicationPhysicalPath;
            var dotvvmConfiguration = app.UseDotVVM(applicationPhysicalPath);
    
            // register routes
            dotvvmConfiguration.RouteTable.Add("Default", "", "Views/default.dothtml", null);
        }
    }
}
```
