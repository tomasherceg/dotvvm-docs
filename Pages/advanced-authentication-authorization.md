## Authentication and Authorization

There are some special things you need to be aware of before you start working 
with the authentication.

**DotVVM** doesn't implement any specific authentication features, however it 
can use advantage of the common ASP.NET authentication system. The fact, whether
the user is authenticated and in which role he is, is determined by the 
`HttpContext.Current.User` property. It's the same as in other ASP.NET frameworks.


### Restricting Access to ViewModels and ViewModel Methods

**DotVVM** contains the `[Authorize]` attribute. You can apply it on the whole 
viewmodel, or on a specific viewmodel method, which is referenced by a command binding.

_Warning: Only the method referenced by a command binding will be checked for this 
attribute. If you call another methods from the command binding target, the attribute
on them will be ignored. Be sure to always mark the method which is called by the command binding!_

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
            // to call this method.
        }
    }
}
```

