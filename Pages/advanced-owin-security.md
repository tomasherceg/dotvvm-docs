## Using Owin Security for Authentication

Let's see how to use the OWIN Security framework. To set up the standard cookie authentication, 
just add this snippet in the `Startup.cs` file.

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

> Please note that authentication middlewares should be always registered **before DotVVM**. The authentication middleware needs to determine the current user (e.g. by parsing the authentication token from the cookie) before DotVVM takes control of the HTTP request. 

> The `DotvvmAuthenticationHelper.ApplyRedirectResponse` method is used to perform the redirect because DotVVM uses a different way to handle redirects. Because the HTTP requests invoked by the command bindings are done using AJAX, DotVVM cannot return the HTTP 302 code. Instead, it returns HTTP 200 with a JSON object which instructs DotVVM to load the new URL.

### Login Page with OWIN Cookie Authentication

In the login page, you need to verify the user credentials and create the `ClaimsIdentity` object that represents the logged user's identity. Then, you need to pass the identity to the `OwinContext.Authentication.SignIn` method:

```CSHARP
public class LoginViewModel : DotvvmViewModelBase
{
    public string UserName { get; set; }
    public string Password { get; set; }        

    public void Login() 
    {
        if (VerifyCredentials(UserName, Password)) 
        {
            // the CreateIdentity is your own method which creates the IIdentity representing the user
            var identity = CreateIdentity(UserName);
            Context.OwinContext.Authentication.SignIn(identity);
            Context.RedirectToUrl("/signedIn");
        }
    }

    private bool VerifyCredentials(string username, string password) 
    {
        // verify credentials and return true or false
    }

    private ClaimsIdentity CreateIdentity(string username) 
    {
        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.Name, username),

                // add claims for each user role
                new Claim(ClaimTypes.Role, "administrator"),
            },
            DefaultAuthenticationTypes.ApplicationCookie);
        return identity;
    }
}
```

### Using Social Providers

If you want to let the users to sign in using Facebook or other third party identity provider,
you need to do several things. 

First, you need to install the appropriate NuGet package - `Microsoft.Owin.Security.Facebook`.

In order to redirect to the Facebook login page, you can use this code:

```CSHARP
public void LoginWithFacebook()
{
    var properties = new AuthenticationProperties()
    {
        RedirectUri = "http://myapp.com/Register"
    };
    Context.OwinContext.Authentication.Challenge(properties, "Facebook");
    Context.InterruptRequest();
}
```

Please note that after the `Authentication.Challenge` call which sets the HTTP code to 403, we need to call
`Context.InterruptRequest()`. This will tell DotVVM to stop executing this request and not to manipulate with the HTTP response.

To configure the Facebook Authentication, use the following code in the `Startup.cs`:

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

### Using Azure Active Directory

In order to use Azure Active Directory as the identity provider, you can use the Open ID Connect middleware using the `Microsoft.Owin.Security.OpenIdConnect` package.

```CSHARP
app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ApplicationCookie);

var authority = new Uri("https://login.microsoftonline.com/common/");
app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
    {
        ClientId = "<<CLIENT_ID>>",
        Authority = authority.ToString(),
        MetadataAddress = new Uri(authority, ".well-known/openid-configuration").ToString(),
        Notifications = new OpenIdConnectAuthenticationNotifications
        {
            AuthenticationFailed = context =>
            {
                context.HandleResponse();
                DotvvmAuthenticationHelper.ApplyRedirectResponse(context.OwinContext, "/error");
                return Task.FromResult(0);
            },
            RedirectToIdentityProvider = context =>
            {
                context.ProtocolMessage.RedirectUri = "<<REDIRECT_URI>>";
                context.ProtocolMessage.PostLogoutRedirectUri = context.Request.Uri.ToString();
                return Task.FromResult(0);
            },
            SecurityTokenValidated = context =>
            {
                HttpContext.Current.GetOwinContext().Request.User = new ClaimsPrincipal(context.AuthenticationTicket.Identity);
                
                // here you can e.g. load the user ID from the database and save it as a claim in the identity object 

                return Task.FromResult(0);
            }
        }
    });
``` 

You need to combine this provider with e.g. the cookie authentication provider to store the identity in the cookie.