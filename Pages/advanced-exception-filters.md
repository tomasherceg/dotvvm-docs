## Exception Filters

If you want to handle exceptions only, we have also a base class `ExceptionFilterAttribute`.
It derives from **ActionFilterAttribute**, however it adds the **OnException** method.

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
        protected override void OnException(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
        {
			LogService.LogException(exception.ToString());
        }       
    }
}
```


Sometimes you expect that the command ends with an exception, however you don't
want to show the user the error page. Instead, you need to process the exception
and make some change in the UI (e.g. display an error message).

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
        protected override void OnException(IDotvvmRequestContext context, ActionInfo actionInfo, Exception exception)
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