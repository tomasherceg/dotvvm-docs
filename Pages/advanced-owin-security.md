## Using Owin Security for Authentication

Let's see how to use the OWIN Security framework. To set up the standard cookie authentication, 
just add this snippet in the **Startup.cs** file.

>Please note that authentication middlewares should be always registered **before** DotVVM. Otherwise the authorization won't work properly.

```CSHARP
app.UseCookieAuthentication(new CookieAuthenticationOptions()
{
    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
});
```

In the login page, you have to verify the user credentials and create the `IIdentity` object that represents the logged user identity.
Typically, you want to use `ClaimsIdentity` for this purpose. Then, you can call the `OwinContext.Authentication.SignIn` method:

```CSHARP
using System;
using System.Security;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmDemo.ViewModels
{
    public class LoginViewModel : DotvvmViewModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }        
    
        public void Login() 
        {
            // IsValidCredentials is your own method which returns true if the username and password is valid
            if (IsValidCredentials(UserName, Password)) 
            {
                
                // CreateIdentity is your own method which creates the IIdentity representing the user
                IIdentity identity = CreateIdentity(UserName);
                Context.OwinContext.Authentication.SignIn(identity);
                Context.RedirectToUrl("/signedIn");
            }
        }
    }
}
```

### Using Social Providers

If you want to allow the users to sign in using Facebook or other third party authentication provider,
you'll need to do several things.

If you want to redirect the the Facebook, you can use this code.
Notice, that after `Authentication.Challenge` call, which sets the HTTP code to 403, we need to call
`Context.InterruptRequest()`. This interrupts the execution of this method and prevents DotVVM to do 
additional stuff that would come after this method. The next OWIN middleware will take the request
and finish the job.

```CSHARP
public void LoginFacebook()
{
    var properties = new AuthenticationProperties()
    {
        RedirectUri = "http://myapp.com/Register"
    };
    Context.OwinContext.Authentication.Challenge(properties, "Facebook");
    Context.InterruptRequest();
}
```

### Handling Redirects

In the default configuration, the Owin Security middleware replaces the 403 status code
with 302, which means "redirect". The problem is, that the postback was made by `dotvvm.postBack`
and this function uses AJAX to perform the call. If the server sends the HTTP 302, the postBack
function is not able to detect it and tries to load the destination page instead immediately.

Therefore, we need to adjust the redirect request to send HTTP 200 and a JSON-serialized object
with the URL where DotVVM should redirect. We have a handy method created just for this purpose.

Change the UseFacebookAuthentication to look like this:

```CSHARP
app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
{
    ...
    Provider = new FacebookAuthenticationProvider()
    {
        OnApplyRedirect = context => DotvvmAuthenticationHelper.ApplyRedirectResponse(context.OwinContext, context.RedirectUri),
        ...
    }
});
```

Now, the redirect to the social login page should work correctly.
The rest of the job is the same like in ASP.NET MVC or other ASP.NET technology.

The same applies for all external login providers - Google, Twitter or Microsoft Account and others, even for the cookie authentication.

```CSHARP
app.UseCookieAuthentication(new CookieAuthenticationOptions()
{
    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    LoginPath = new PathString("/login"),       // don't use ~/login here - the ~ in URLs is a DotVVM feature, OWIN security doesn't know it
    Provider = new CookieAuthenticationProvider()
    {
        OnApplyRedirect = e => DotvvmAuthenticationHelper.ApplyRedirectResponse(e.OwinContext, e.RedirectUri)
    }
});
```

