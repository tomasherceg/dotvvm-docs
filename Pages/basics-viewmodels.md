## ViewModels

The **viewmodel** in **DotVVM** can be any C# class that is JSON-serializable. The viewmodel holds the _properties_ required in the page 
and _methods_ that can be called from the page (by clicking a button for example).

The viewmodel should represent complete "state" of the page. If you save the viewmodel and after some time you load it into the same view,
the page should be in the exactly same state. Put everything you need to remember for the next user action in the viewmodel.

Here are the recommendations for the viewmodel:

+ The viewmodel is a C# class that derives from `DotvvmViewModelBase`. 

+ It contains several properties that hold the data. The property can be of a simple type (string, int, double...), 
a collection (List&lt;T&gt; or array) or other objects that comply with this paragraph.

+ It contains several methods that can be called from the UI. These methods shouldn't do anything complicated. If there is 
some complex stuff that needs to be done, the method wil use some other class to do the job. 
In general, the viewmodel methods should only gather data from the viewmodel, call a method that does the job and after it's finished, 
update the viewmodel with results of the called method. 

Please don't put code that retrieves the data or updates records in the database, sends e-mails or does anything complicated 
directly in the viewmodel. You'll end with one big mess which will be difficult to maintain.
See our TODO samples to see how to architect the application in the layers.


### DotvvmViewModelBase

If the viewmodel derives from the `DotvvmViewModelBase`, it can override the `Init`, `Load` and `PreRender` methods. The lifecycle 
of the request looks like this. On the left side, you can see what's going on when the client access the page first time 
(the GET request). On the right side you can see what happens during the postback (when the user clicks a button).
<img src="/Views/Docs/Pages/basics-viewmodels-img1.png" alt="Dotvvm Page Lifecycle" />

You can also leverage the `Context` property that is defined in the `DotvvmViewModelBase` class. The Context has several properties 
and methods you can use:
+ `IsPostBack` - Determines whether the current request is postback, or whether the page is loaded for the first time.
+ `ModelState` - If you have some custom validation logic, you can report errors to the UI using this object's `AddModelError` method. 
Or you can use the `IsValid` property to determine whether there are some validation errors. 
However, in most cases you'll be good with the `FailOnInvalidViewModel` function. It checks the validity of the viewmodel itself and 
throws an exception if the viewmodel is not valid. The request execution will be interrupted and the validation errors will be 
displayed in the client's browser.
+ `Parameters` - If the page route contains some parameters, you can get them from this dictionary.
+ `Query` - Contains the querystring parameters in the URL.
+ `OwinContext` - Gives you access to the OWIN context of the current request. It's useful when you need to work with cookies, authentication etc.
+ `Redirect` and `RedirectPermanent` - Redirects the user to the specified URL. The request execution is interrupted by this call. 
If you put something after the Redirect call, it won't be executed.
If you use the overload with two arguments, pass the route name as a first argument and the route parameters as the second one.
+ `InterruptExecution` - You may use this function when you want to pass the request to the following OWIN middleware. 
It is used in special cases (like authentication etc.).
+ `ChangeCurrentCulture` - This function allows you to change the culture of the thread that executes the request.


## Binding Directions

You may want to customize which properties are transferred from the server to client and from client to the server. 
You can achieve this by using the `[Bind(direction)]` attribute. 

The direction is an enum with the following options - `Both`, `ServerToClient`, `ClientToServer` and `None`.

* **Both** is the default value - the property is transferred in both ways.
* **ServerToClient** - the changes of the property on the client side are not transferred to the server.
* **ClientToServer** - the server only reads the value of the property set by the client.
* **None** - the property is not serialized in any way.
