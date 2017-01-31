## Validation

**DotVVM** support the Model Validation mechanism known from other ASP.NET technologies, like MVC, Web API or WebForms. 
You can validate either whole viewmodel, or only a part of it. You can also add your own validation logic in the code 
and declare your own validation attributes.


If you want to validate some property, just use standard attributes from the `System.ComponentModel.DataAnnotations` namespace. 
DotVVM can translate some validation rules into javascript, so the validation can be executed also on the client side. 

Currently, the following attributes are evaluated on the client side:

+ `Required`
+ `RegularExpression`
+ `Range`

However, all rules including those that can be translated to javascript, are still executed on the server side, 
and the validation errors will be displayed to the user in case the validation fails.

It's also possible to use only server side validation by turning client side validation off in the [configuration](/docs/tutorials/basics-configuration/{branch}).
This allows that all validations will be checked even if one of the client side supported validations fails.
```CSHARP
config.ClientSideValidation = false;
```

Apply the validation attributes on viewmodel properties. Optionally, you can set the `ErrorMessage` parameter directly, or use the 
other parameters of the `Required` attribute to get localized error message from the resource file.

```CSHARP
[Required]
public string NewTaskTitle { get; set; }

[Required(ErrorMessage = "The password is required!")]
public string Password { get; set; }
```

### Validation Controls

In the page, you can use the [ValidationSummary](/docs/controls/builtin/ValidationSummary/{branch}) control to renders a list of all validation errors.
 
```DOTHTML
<dot:ValidationSummary />
```

The second options is to use the [Validator](/docs/controls/builtin/Validator/{branch}) to display errors for an individual field.

```DOTHTML
<dot:TextBox Text="{value: NewTaskTitle}" />
<dot:Validator Value="{value: NewTaskTitle}">*</dot:Validator>
```

This will display the `*` character when the field contains invalid value. The `Value` property contains a binding to the viewmodel property which is being validated.

The `Validator` control has several properties you can combine as you need:

* `HideWhenValid` - set to **false** if you need this control to remain visible even when the field is valid.

* `InvalidCssClass` - the CSS class specified in this property will be set to this control when the field is not valid. 

* `ShowErrorMessageText` - the text of the error message will be displayed inside this control.

* `SetToolTipText` - the text of the error message will be set as the `title` attribute of the element.


In some cases, you may need to apply the `Validator` properties on any other element, for example the `<div>`.
If the field is not valid and you need to apply a CSS class to a div, you can just use this:

```DOTHTML
<div Validator.InvalidCssClass="has-error" Validator.Value="{value: FirstName}">
   your content
</div>
```

The `Validator.HideWhenValid`, `Validator.InvalidCssClass`, `Validator.ShowErrorMessageText` and `Validator.SetToolTipText` are inherited to the child elements, so you
can set them globally for example on the `<body>` element in the master page. Unless you override them on a specific HTML element, their value is used on all elements
which have the `Validator.Value` set. 


### Validation Target

You often need to validate only a part of the viewmodel. Therefore, DotVVM has the `Validation.Target` property:

```DOTHTML
...		
    <fieldset Validation.Target="{value: Customer}">
    ...
    </fieldset>
...
```

You can apply this property to any HTML element and to almost all DotVVM controls. In the example, for all elements inside the `fieldset`, 
the validation will be executed only on the `Customer` property of the ViewModel. This applies also to the `ValidationSummary` control - 
if this control or some of its parents has `Validate.Target` property set, only the errors from the specified target will be displayed.
The rest of the ViewModel validation rules will not be checked. 

If you don't set the `Validation.Target`, the whole viewmodel is validated.

You can also disable validation on a part of the page or on a specific control, by using `Validation.Enabled="false"`. You often need to do this e.g. for delete 
and cancel button where the values in the form don't need to be valid.  

> By default, the validation is enabled. If you are using validation attributes in your viewmodel and any button in the page doesn't do the postback,
> it's because the viewmodel is not valid and you have no `ValidationSummary` or `Validator` control to display the errors. 

> If you turn on the debug mode in the [configuration](/docs/tutorials/basics-configuration/{branch}), a red notification in the top right corner of the screen appears 
> if the postback was canceled because the viewmodel is not valid.
