## Filter Registration

You have created some filters, now it's time to use them.

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

In the example above, there is a **ModelValidationFilter** applied on the whole viewmodel, which means, that every command on a method on such viewmodel will use
this filter.

If you call the Command1 from a button in the page, also the **MyCustomFilter** will be applied. 

Like with the `Authorize` attribute (which is actually an action filter), the filter is executed if the command binding in the page references the method. If you 
call **Command1()** inside the **Command2()** method and the binding in the page references the Command2 method, the **MyCustomFilter** will not be executed.


### Global Filters

If you need to apply a filter globally, navigate in the **Startup.cs** class and add register the filter in the global filter collection in the **DotvvmConfiguration** object.

```CSHARP
dotvvmConfiguration.Runtime.GlobalFilters.Add(new ErrorHandlingActionFilter());
```



### Multiple Filters

You can apply mutliple filters on a viewmodel or a method. The filters are called in the order you have added them to the GlobalFilters collection, or in the order of the attributes
on the class or a method.

Global filters are executed first, next come the viewmodel-level filters, and finally the method-level filters are executed.