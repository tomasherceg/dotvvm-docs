## Validation

In **DotVVM**, you can use Model Validation known from other ASP.NET technologies, like MVC, Web API or WebForms. 
You can validate either whole viewmodel, or only a part of it. You can also add your own validation logic in the code.


If you want to validate some property, just use standard attributes from **System.ComponentModel.DataAnnotations**. 
DotVVM can translate some validation rules into javascript, so the validation can be executed also on the client side. 
Currently only _Required_ and _RegularExpression_ rules are translated. The other rules will be implemented on the client 
in the future versions. 

However, all rules including those that cannot be translated to javascript, are still executed on the server side, 
and the validation errors will be displayed to the user in case the validation fails.


The validation rules are set on viewmodel properties. You can also set the ErrorMessage parameter directly, or use the 
other parameters of the `Required` attribute to get localized error message from the resource file.
```CSHARP
[Required]
public string NewTaskTitle { get; set; }
```

### Validation Controls

In the page, you can use **ValidationSummary** control that renders all validation errors as a list. 
```DOTHTML
<dot:ValidationSummary />
```

Or you can use **ValidationMessage** to display errors for individual fields.
```DOTHTML
<dot:TextBox Text="{value: NewTaskTitle}" />
<dot:ValidationMessage ValidatedValue="{value: NewTaskTitle}">*</dot:ValidationMessage>
```
This will display the `*` character when the field contains invalid value. The _ValidatedValue_ contains 
a binding to the viewmodel property that is being validated.

The `ValidationMessage` control has several properties you can combine as you need:

* `HideWhenValid` - set to **true** if you need the control to remain visible even when the field is valid.

* `InvalidCssClass` - the CSS class specified in this property will be set to the control when the field is not valid. 

* `ShowErrorMessageText` - the text of the error message will be displayed inside the control.

* `SetToolTipText` - the text of the error message will be set as the `title` attribute of the element.


In some cases, you may need to apply the **ValidationMessage** properties on any other element, for example to a div.
If the field is not valid and you want to apply a CSS class to a div, you can just use this:

```DOTHTML
<div ValidationMessage.InvalidCssClass="field-validation-error">
   your content
</div>
```



### Validation Scopes
Sometimes you don't want to validate the whole viewmodel - you may only want to validate only a part of it. 
Therefore you can apply the `Validate.Target` property:
```DOTHTML
...		
    <fieldset Validate.Target="{value: Customer}">
    ...
    </fieldset>
...
```
You can apply this property to any HTML element and to almost all DotVVM controls. Everywhere inside the _fieldset_ control in the sample, 
the validation will be executed only on the `Customer` property of the ViewModel. This applies also to the `ValidationSummary` control - 
if this control or some of its parents has `Validate.Target` property set, only the errors from the specified target will be displayed.
The rest of the ViewModel will not be validated. By default, the whole ViewModel is validated.

You can also disable validation on a part of the page by specifying `Validate.Enabled="false"`. 

> By default, the validation is enabled. If you have some validated properties in the viewmodel and a button on the page doesn't do anything,
> it is beause some of the validation rules prevents to make the postback.