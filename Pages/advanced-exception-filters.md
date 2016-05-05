## Exception Filters

If you want to handle exceptions only, we also have a base class `ExceptionFilterAttribute`.
It derives from `ActionFilterAttribute`, however it adds the `OnCommandException` method. Also, there is a method called `OnPageException`. 

The `OnCommandException` is called when the error occurs when the command is executed. A command is a method in the viewmodel triggered 
by the `{command: ...}` or `{controlCommand: ...}` bindings.

The `OnPageException` is called when any other exception that occur when the page is being processed. It catches the exceptions in 
the `Init`, `Load` and `PreRender` in the viewmodel. 

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;

namespace DotvvmDemo
{
    public class ErrorLoggingActionFilter : ExceptionFilterAttribute
    {
        protected override void OnCommandException(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
        {
            // Log exceptions from commands in the viewmodel
			LogService.LogException(exception.ToString());
        }
        
        protected override void OnPageException(IDotvvmRequestContext context, Exception exception)
        {
            // Log other exceptions that occur during the page execution
			LogService.LogException(exception.ToString());
        }              
    }
}
```

<br />

### Command Exception Handling

In many apps, the commands sometimes end with an exception. However you don't want to show the error page to the user.  Instead, you need to 
log the exception and display an error message to the user.

You can use something like this:

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;
namespace DotvvmDemo
{
    public class ErrorHandlingActionFilter : ExceptionFilterAttribute
    {
        protected override void OnCommandException(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
        {
			// AppViewModelBase declares the ErrorMessage property to display error messages
			// If it is set, the master page will display the error message alert.
            if (context.ViewModel is AppViewModelBase)
            {
				((AppViewModelBase) context.ViewModel).ErrorMessage = exception.Message;
                
				// We need the request to end normally, not with an error
                context.IsCommandExceptionHandled = true;
            }
        }       
    }
}
```

The `AppViewModelBase` is a base class for all viewmodels in the application and has the `ErrorMessage` property. If the request execution should 
continue without error, we need to set `context.IsCommandExceptionHandled` to `true`.

<br />

### Custom Error Pages

If the exception occurs during the `Init`, `Load` and `PreRender` phase, you often need to redirect the user to an error page. 

You can do it in the `OnPageException` method like this:

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;
namespace DotvvmDemo
{
    public class ErrorHandlingActionFilter : ExceptionFilterAttribute
    {
        protected override void OnPageException(IDotvvmRequestContext context, Exception exception)
        {
            // Suppress the default DotVVM error page
			context.IsPageExceptionHandled = true;
            
            // TODO: Log the exception details
            
            // Redirect to the /error500 page 
            context.RedirectToUrl("/error500");
        }       
    }
}
```