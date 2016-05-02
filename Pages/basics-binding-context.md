## Binding Context

Each HTML element or DotVVM control has the `DataContext` property. Using this property, you can change the context in which the binding is evaluated.

```DOTHTML
@viewModel AddressViewModel, DotvvmDemo

<div DataContext="{value: Customer}">
	{{value: Name}}
</div>
```

The `DataContext` property in the sample means that all bindings inside the **div** element will be evaluated in the context of the 
`Customer` property of the viewmodel. 

If you didn't use the `DataContext` binding, the binding inside the **div** would have to be `{value: Customer.Name}`.

```CSHARP
public class AddressViewModel {	
	public Customer Customer { get; set; }	
}

public class Customer {
	public string Name { get; set; }	
}
```

There is also one helpful feature. If the `Customer` in the viewmodel is null, the **div** element is hidden and the bindings 
inside are not evaluated (so you won't get any exceptions). If you don't want to hide the **div** element, just initialize the `Customer` property 
with some non-null value.

<br>

### Binding Context Variables
 
You can use the following reserved names in **command** and **value** expressions:
 
* `_root` goes to the top-level ViewModel object.
* `_parent` goes to the parent binding context.
* `_parent{#number}` goes to the parent #number times
* `_this` references the current context. It is useful only if you want to bind directly to the ViewModel object (e.g. if you want to 
display a collection of strings, or pass current binding context to a method): `{value: _this}`
