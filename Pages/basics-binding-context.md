## Binding Context

Each HTML element or DotVVM control can specify the **DataContext** property. Using this property, you can change the binding context.

```DOTHTML
@viewModel AddressViewModel, DotvvmDemo

<div DataContext="{value: Customer}">
	{{value: Name}}
</div>
```

Using the **DataContext** binding, we have declared, that inside the **div** element, all bindings are evaluate in the context of the 
Customer property of the viewmodel. The _Name_ will be taken from the Customer class and not from the AddressViewModel class.

```CSHARP
public class AddressViewModel {	
	public Customer Customer { get; set; }	
}

public class Customer {
	public string Name { get; set; }	
}
```

There is also one speciality - if the **Customer** property will be null, the contents of the **div** will be hidden and the bindings 
inside won't be evaluated. It is a great thing if you need some optional parts of the viewmodel.