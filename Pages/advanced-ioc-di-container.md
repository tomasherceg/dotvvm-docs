## IoC/DI Containers

Dependency Injection is used widely in many large applications. **DotVVM** allows you to have your services injected in the viewmodel constructor or properties.

```CSHARP
public class CustomersViewModel 
{
    // the parameters will be injected automatically by the DI container
    public CustomersViewModel(CustomerService customerService, ILogging log) 
    {
        ...        
    }

    // this service can be injected too
    [Bind(Direction.None)]
    public IAdditionalService AdditionalService { get; set; }
}
```

Basically, if you need any services in your viewmodel, you can request them in the constructor as parameters, or you can declare a public property in the viewmodel. In that case, don't forget to use the `[Bind(Direction.None)]` attribute to tell the serializer that it should not care about this property.

DotVVM uses the `Microsoft.Extensions.DependencyInjection` library to configure and resolve services.

* [IoC/DI Containers (OWIN)](/docs/tutorials/advanced-ioc-di-container-owin/{branch})
* [IoC/DI Containers (ASP.NET Core)](/docs/tutorials/advanced-ioc-di-container-aspnetcore/{branch})
