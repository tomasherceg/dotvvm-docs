## Authentication and Authorization

There are some special things you need to be aware of before you start working 
with the authentication.

**DotVVM** doesn't implement any specific authentication features, however it 
can use advantage of the common ASP.NET authentication system. The fact, whether
the user is authenticated and in which role he is, is determined by the 
`OwinContext.User` property. It's the same as in other ASP.NET frameworks.


### Restricting Access to ViewModels and ViewModel Methods

**DotVVM** contains the `[Authorize]` attribute. You can apply it on the whole 
viewmodel, or on a specific viewmodel method, which is referenced by a command binding.

>Only the method called directly from a command binding, and the class where that method is declared, 
> are checked for the Authorize attribute. If you call the method from C# code, the attribute is ignored.

```CSHARP
using System;
using System.Threading.Tasks;
using DotvvmWeb.BL.Facades;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo.ViewModels
{
    [Authorize]
    public class AdminViewModelBase : DotvvmViewModelBase
    {
        // The page with this viewmodel will return 403 Forbidden
        // if the user is not authenticated.

        // No commands will be accepted.
    }
}
```

Also, you can limit the access to a specific user roles.

```CSHARP
using System;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo.ViewModels
{
    public class AdminViewModelBase : DotvvmViewModelBase
    {
        [Authorize(Roles = new[] { "Admin" })]
        public void DeleteUser(int id)
        {
            // Only the users with the Admin role will be able
            // to call this method from the command binding.
        }
    }
}
```

If you use the `Microsoft.Owin.Security` package for the authentication, you should read 
[Using OWIN Security for Authentication](/docs/tutorials/advanced-owin-security/{branch}) chapter. 