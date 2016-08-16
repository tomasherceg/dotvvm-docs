## Built-in Controls

Currently, **DotVVM** contains about 20 built-in controls.
For more information, read the [Built-in Control Reference](/docs/controls/builtin/Button/{branch}).

### Built-in Controls

#### Forms
+ [Button](/docs/controls/builtin/Button/{branch}) - button that triggers the postback
+ [ComboBox](/docs/controls/builtin/ComboBox/{branch}) - standard HTML select with advanced binding options
+ [CheckBox](/docs/controls/builtin/CheckBox/{branch}) - standard HTML checkbox
+ [HtmlLiteral](/docs/controls/builtin/HtmlLiteral/{branch}) - renders a HTML in the page
+ [LinkButton](/docs/controls/builtin/LinkButton/{branch}) - hyperlink that triggers the postback
+ [ListBox](/docs/controls/builtin/ListBox/{branch}) - standard HTML listbox
+ [Literal](/docs/controls/builtin/Literal/{branch}) - renders a text in the page, supports date and number formatting
+ [RadioButton](/docs/controls/builtin/RadioButton/{branch}) - standard HTML radiobutton
+ [TextBox](/docs/controls/builtin/TextBox/{branch}) - HTML input, password or textarea

#### Validation
+ [Validator](/docs/controls/builtin/Validator/{branch}) - displays a validation error for particular field
+ [ValidationSummary](/docs/controls/builtin/ValidationSummary/{branch}) - displays all validation errors in the page

#### Collections
+ [DataPager](/docs/controls/builtin/DataPager/{branch}) - displays a list of pages in the grid
+ [GridView](/docs/controls/builtin/GridView/{branch}) - displays a table grid with sort functionality
+ [Repeater](/docs/controls/builtin/Repeater/{branch}) - repeats a template for each item in the collection

#### Master Pages
+ [Content](/docs/controls/builtin/Content/{branch}) - defines a content that is hosted in ContentPlaceHolder
+ [ContentPlaceHolder](/docs/controls/builtin/ContentPlaceHolder/{branch}) - defines a place where the content page is hosted
+ [SpaContentPlaceHolder](/docs/controls/builtin/SpaContentPlaceHolder/{branch}) - a ContentPlaceHolder which works as a Single Page Application container

#### Other
+ [InlineScript](/docs/controls/builtin/InlineScript/{branch}) - includes an inline javascript script in the page
+ [RequiredResource](/docs/controls/builtin/RequiredResource/{branch}) - includes a script or style resource in the page
+ [UpdateProgress](/docs/controls/builtin/UpdateProgress/{branch}) - displays specified content during the postback

&nbsp;

### Common Control Properties

All DotVVM controls have some properties in common because they all derive from the `DotvvmControl` class. 
You can use most of these properties on HTML elements too.

+ `DataContext` - changes the binding context for the content of the control / element.
+ `ID` - specifies an ID of the control. Because the control can appear in the page multiple times (e.g. when it is inside the Repeater control), the real
  id of the control might be different and sometimes it is calculated on the client side. You can enforce the ID to be the same as you specified in the markup
  by setting the `ClientIDMode` property to `Static`. 
+ `Visible` - hides the control in the page (using CSS `display: none`).

### HTML Attributes And DotVVM Controls

You can also add any HTML attribute to almost all controls. You can also use binding in the HTML attributes.
All additional attributes used on the DotVVM control will be added to the main HTML element rendered by the control.

```DOTHTML
<dot:TextBox Text="{value: FirstName}" class="btn btn-primary" placeholder="{value: FirstNamePlaceholder}" />
```

This produces the following HTML:

```DOTHTML
<input type="text" data-bind="value: FirstName, attr: { 'placeholder': FirstNamePlaceholder }" class="btn btn-primary" />
```

You can see that the `class` attribute has been added to the output, and the `placeholder` attribute was translated to Knockout JS `attr` binding.

