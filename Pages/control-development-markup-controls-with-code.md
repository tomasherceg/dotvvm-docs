## Markup Controls with Code

Sometimes you need to parameterize the markup control in the page where you use it. 
For example, you don't need to display the Phone field in the Billing address, and you want also the control from the last sample
to generate the fieldset and legend tags itself.

You can create a markup control using the _Add > New Item_ in the Solution Explorer context menu and after you choose the name of the control,
click on the checkbox which generates the code behind file for you.

<p><img src="{imageDir}control-development-markup-controls-with-code-1.png" alt="Creating the DOTCONTROL with code" /></p>

The code behind class will look like that. Notice that it derives from `DotvvmMarkupControl` which is required for all markup controls.

```CSHARP
public class AddressEditor : DotvvmMarkupControl
{

}
```

Now we want to add two properties into the control. The first one is `Title`, which will appear inside the **legend** tag.
The second would be `DisplayPhoneNumber` property which will hide the Phone field. 

The properties in **DotVVM** control cannot be simple C# properties with default getter and setter. To make data-binding work,
you have to expose those properties as a `DotvvmProperty` object which contains metadata about the property. It is quite similar 
to dependency properties in WPF.

We have prepared an easy-to-use code snippet in the Visual Studio extension, so to declare a property you only need to type
`dotprop` and press Tab. The property declaration will be generated for you.

So, type in `dotprop` and change the name to `Title`, the type to `string`, the containing class to `AddressEditor` and
the default value to `"Address"`:

```CSHARP
public string Title
{
    get { return (string)GetValue(TitleProperty); }
    set { SetValue(TitleProperty, value); }
}
public static readonly DotvvmProperty TitleProperty
        = DotvvmProperty.Register<string, AddressEditor>(c => c.Title, "Address");
```

Then create a second property `DisplayPhoneNumber` of type `bool` with default value `true`.

```CSHARP
public bool DisplayPhoneNumber
{
    get { return (bool)GetValue(DisplayPhoneNumberProperty); }
    set { SetValue(DisplayPhoneNumberProperty, value); }
}
public static readonly DotvvmProperty DisplayPhoneNumberProperty
        = DotvvmProperty.Register<bool, AddressEditor>(c => c.DisplayPhoneNumber, true);
```

### ControlProperty Binding

Now, you can get the value of these properties using the `{controlProperty: Title}` binding. 
Also, the markup control has to declare the `@baseType` directive to specify the code behind.
After you apply these changes, the DOTCONTROL file will look like this:

```DOTHTML
@viewModel DotvvmDemo.Model.IAddress, DotvvmDemo
@baseType DotvvmDemo.Controls.AddressEditor, DotvvmDemo

<fieldset><legend>{{controlProperty: Title}}</legend>
    <table>
        <tr>
            <td>Street: </td>
            <td><dot:TextBox Text="{value: Street}" /></td>
        </tr>
        ...
        <tr Visible="{controlProperty: DisplayPhoneNumber}">
            <td>Phone: </td>
            <td><dot:TextBox Text="{value: Phone}" /></td>
        </tr>
    </table>
</fieldset>
```

In the page, we can now use the control like this:

```DOTHTML
    <cc:AddressEditor DataContext="{value: BillingAddress}" Title="Billing Address" DisplayPhoneNumber="false" />
    <cc:AddressEditor DataContext="{value: DeliveryAddress}" Title="Delivery Address" />
```

It will work even if you put a binding into the Title and DisplayPhoneNumber properties.

_Careful: Don't try to set a value of a property from code and then reference it using `controlProperty` binding. It won't work.
The `controlProperty` only propagates the value or a binding which was set to that property in the markup file where the control is used._


### ControlCommand Binding

Now let's add a button which will fill the fields in the `AddressEditor` with the address the user had on his last order.
Yes, we could put this function to the viewmodel, however in that case the `IAddress` interface could be implemented by many
classes and we would have to add the implementation of `FillLastAddress` to all those classes.

Instead, we can use the `controlCommand` binding and implement this logic in our control. Add this to the markup control:

```DOTHTML
<dot:Button Text="Fill Last Address" Click="{controlCommand: FillLastAddress()}" />
````

And then, add this method to the `AddressEditor` class:

```CSHARP
public void FillLastAddress() 
{
    var address = ... // retrieve data from the database
    
    var target = (IAddress)DataContext;
    target.Street = address.Street;
    target.City = address.City;
    ...
}
```

_Caution: This is only a sample. In you app, maybe it would be wiser to implement this logic in the viewmodel. It's up to you
to decide what's appropriate and choose the best solution. This is only a demonstration of possibilities of markup controls._


### Updating the ViewModel Properties

Data-binding in **DotVVM** can do one more thing - update the source property. Forget the address editor and imagine we have a
`NumericUpDown` control which has one textbox and two buttons. The buttons increase or decrease the value of a number
inside the textbox.

In the page, the control is used like this:

```DOTHTML
<cc:NumericUpDown Value="{value: MyNumber}" />
```

The buttons in the control are using `controlCommand` binding to call function `Up` and `Down` in the code behind class of the control.
The **Up** method looks like this:

```CSHARP
public void Up()
{
    Value++;
}
```

Notice that we are changing a value of a property which has a data-binding in the page. DotVVM can update the value in the viewmodel because
because the `Value` is not a standard property. Ot is a DotVVM property and in the setter it calls the `SetValue` function. This function checks
the value and if it is a binding, it will try to update the corresponding property in the viewmodel.