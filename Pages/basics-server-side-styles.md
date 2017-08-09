## Server-side Styles

**DotVVM** supports Server-side styles which enable changing the style or attributes of specified controls across whole application.

To use them you have to register `Style` in `StyleRepository` which is a property of `DotvvmConfiguration`. You also have to specify the type of the control which has to derive from `DotvvmBindableObject` or use a parameter with tag name of HTML element:

```CSHARP
//modify all controls derived from ButtonBase
config.Styles.Register<ButtonBase>();

//modify all HTML elements with tag name input
config.Styles.Register("input");
```

>If you register the style by specifying the tag name **DotVVM** controls will not be modified

It is also possible to set a condition under which the styles will be applied. To do that use `Register(Func<StyleMatchContext, bool>)`. If this function returns `true` the styles are going to be applied otherwise nothing happens.

```CSHARP
//this will hide every control derived from ButtonBase that does not have the Click property
config.Styles.Register<ButtonBase>(b => !b.HasProperty(ButtonBase.ClickProperty), allowDerived: true)
    .SetAttribute("style", "display:none;");
```    

`Register` method returns an instance of `StyleBuilder` that lets you modify the control. You can set default values of attributes and properties or override them completely.

```CSHARP
//this will change class on all buttons that do not have any
config.Styles.Register<Button>()
  .SetAttribute("class", "ButtonClass");

//this will override class of all textboxes
config.Styles.Register<TextBox>()
  .SetAttribute("class", "TextBoxClass", append: true);

//this will override the text of all buttons
config.Styles.Register<Button>()
  .SetDotvvmProperty(Button.TextProperty, "Button");
```

>`SetAttribute` has the default value of append `true` while `SetDotvvmProperty` has `false`
