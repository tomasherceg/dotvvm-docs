## Routing

Every page needs to be registered in the route table. DotVVM doesn't allow to visit the page by just putting its path in the URL. 

Routes are configured in the `DotvvmStartup` class in the `Configure` method.

### Registering Routes Ony By One

```CSHARP
config.RouteTable.Add("Page", "page", "Views/page.dothtml", new { });
```

+ The first argument is the name of the route. You'll need it when you need to do redirects or generate hyperlinks from one page to another.

+ The second argument is the route URL. It can contain route parameters (e.g. `"/product-detail/{ProductId}"`) which you can read in the viewmodel of the target page. 

+ The third argument is the path to the `.dothtml` file which will be used if the URL in the client's browser matches the second argument. 
Because the file is in the **Views** folder, we pass the `Views/page.dothtml` path.

+ The fourth argument (optional) specifies default values for route parameters. If the parameter value is not passed in the URL, the value from this parameter will be used.
You can pass an anonymous object, or you can use `IDictionary<string, object>`. 

If you need to register a route which should not be treated as dothtml file (e.g. if you need a handler which serves files or generates RSS feeds). In this case you can
write a [custom presenter](/docs/tutorials/advanced-custom-presenters/{branch}) and specify a method, that returns it, as a fifth parameter.

### Route Parameters

Consider the following example. We need to create a page with customer details. There are two cases we need to cover - creating a new customer, and editing an existing one.

In the first case, the URL should be `admin/customer`, in the second, the URL should contain the ID of the customer we need to edit, e.g. `admin/customer/3`. The route 
registration will look like this:

```CSHARP
config.RouteTable.Add("AdminCustomer", "admin/customer/{Id}", "Views/admin/customer.dothtml", new { Id = 0 });
```

In the viewmodel of the page, we can access the route parameter value using this code:

```CSHARP
var customerId = Convert.ToInt32(Context.Parameters["Id"]);
if (customerId == 0) 
{
    // new customer
} 
else 
{
    // existing customer
}
```

We can also register make the parameter optional (without the default value):

```CSHARP
config.RouteTable.Add("AdminCustomer", "admin/customer/{Id?}", "Views/admin/customer.dothtml");
```

And we can also use the route parameter constraints:

```CSHARP
config.RouteTable.Add("AdminCustomer", "admin/customer/{Id:int}", "Views/admin/customer.dothtml", new { Id = 0 });
```

DotVVM currently supports the following route constraints:

* `int` - any integer number
* `posint`- a positive integer number (or zero)
* `float` - anything that can be parsed by `float.Parse` 
* `guid` - a Guid value

<br />

If you have a larger project, you may need to [auto-discover routes](/docs/tutorials/advanced-route-autodiscovery/{branch}) instead of registering the routes one by one.  