## Routing

To make the first page work correctly, you'll also need to register the entry in the route table. Open the **Startup.cs** file and add this line
after the last route registration.
```CSHARP
configuration.RouteTable.Add("MyRoute", "page.dothtml", "/Page", defaultValues: null);
```

+ The first argument is route name. You'll need it when you want to generate a hyperlink that targets the specified page.
+ The second argument is the path to the rwhtml file that will handle the request. If the file is in the Views folder, the value will be `Views/page.dothtml`.
+ The third argument is the URL pattern that determines whether the route will be used or not.
+ The fourth argument specifies default values of route parameters. The parameters in route are placed in curly braces `/products/{ProductId}`. The default value will be used when nothing was passed on that place in the URL.