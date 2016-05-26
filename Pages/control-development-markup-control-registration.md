## Markup Control Registration

You need to register the markup control in `DotvvmStartup.cs` file, before you can use it in the markup. 

The registration of a markup control looks like this:

```CSHARP
config.Markup.Controls.Add(new DotvvmControlConfiguration() 
{ 
    TagPrefix = "cc",
    TagName = "AddressEditor",
    Src = "Controls/AddressEditor.dotcontrol"
});
```

### Using the Markup Control

We have registered our control with the `cc` tag prefix and `AddressEditor` name, so we can just write this:

```DOTHTML
<fieldset>
    <legend>Billing Address</legend>
    <cc:AddressEditor DataContext="{value: BillingAddress}" />
</fieldset>
<fieldset>
    <legend>Delivery Address</legend>
    <cc:AddressEditor DataContext="{value: DeliveryAddress}" />
</fieldset>
```