## Markup-Only Controls

It is very easy to create a markup control. First, you need to create a file with the `.dotcontrol` extension.
Put your markup inside and don't forget about `@viewModel` directive - it can be an interface or a base class,
but the control needs to the type of its `DataContext`.

>Remember that neither markup controls nor master pages create an instace of the viewmodel. They get the viewmodel from the page the user navigated to.  

If your markup control doesn't use data-binding and doesn't depend on viewmodel at all, use `@viewModel System.Object, mscorlib`.


### How To Create

Simple markup controls don't need any C# code. In Visual Studio, right click on a project or folder in the Solution Explorer window, and select Add > New Item.

<p><img src="{imageDir}control-development-markup-only-controls-1.png" alt="Adding a DOTCONTROL file" /></p>

In the next window, don't change anything and proceed.

<p><img src="{imageDir}control-development-markup-only-controls-2.png" alt="Adding a DOTCONTROL file" /></p>

The `.dotcontrol` file can look like this:

```DOTHTML
@viewModel DotvvmDemo.Model.IAddress, DotvvmDemo

<table>
    <tr>
        <td>Street: </td>
        <td><dot:TextBox Text="{value: Street}" /></td>
    </tr>
    ...
    <tr>
        <td>Country: </td>
        <td><dot:ComboBox DataSource="{value: Countries}" SelectedValue="{value: CountryId}" DisplayMember="Name" ValueMember="Id" /></td>
    </tr>
</table>
```

In markup controls, the `@viewModel` directive can be an interface. If you use the markup control from multiple pages, each of them can have completely different viewmodel.
However the markup control requires the `Street`, `Countries` and the `CountryId` properties because it uses them in data-bindings. That's why you have to create the `IAddress` 
interface which contains these properties. 

Then, on all places you use your markup control, the [binding context](/docs/tutorials/basics-binding-context/{branch}) must implement the `IAddress` interface. 

