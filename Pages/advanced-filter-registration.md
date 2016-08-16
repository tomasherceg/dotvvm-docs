## Filter Registration

DotVVM can apply action filters on individual methods, on specific viewmodel classes, or globally for all viewmodels in your application. 

### Method and ViewModel Filters
Because the base classes of the filters inherit from the `Attribute` class, you can apply those filters on a viewmodel or a method as an attribute.

```CSHARP
[ModelValidationFilter]
public class DemoViewModel 
{
	[MyCustomFilter]
	public void Command1() 
	{
	}

	public void Command2() 
	{
	}
}
```

In the example above, there is a `ModelValidationFilter` applied on the whole viewmodel, which means, that every command referencing a method in the viewmodel will use
this filter.

If you call the `{command: Command1()}` from a button in the page, `ModelValidationFilter` and also the `MyCustomFilter` will be applied. 

Like with the `Authorize` attribute (which is an action filter too), the filter is executed if the command binding in the page references the method. If you 
call `Command1()` from the `Command2()` method and the binding in the page references the `Command2` method, the `MyCustomFilter` will not be executed.


### Global Filters

If you need to apply a filter globally, navigate in the `Startup.cs` class and register the filter in the `Runtime.GlobalFilters` collection in the `DotvvmConfiguration` object.

```CSHARP
dotvvmConfiguration.Runtime.GlobalFilters.Add(new ErrorHandlingActionFilter());
```



### Multiple Filters

You can apply multiple filters on a viewmodel or a method. The filters are called in the order you have added them to the GlobalFilters collection, or in the order of the attributes
on the class or a method.

The `OnViewModelCreated`, `OnCommandExecuting` and `OnResponseRendering` methods are executed in the following order:

+ Global filters (in the order they were registered)

+ Filter applied on the viewmodel class (in the order they were registered)

+ Filters applied on the individual methods (in the order they were registered)
 
The `OnCommandExecuted` methods use reverse order of action filters.
