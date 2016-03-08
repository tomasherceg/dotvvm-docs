## Built-in Controls

Currently, **DotVVM** contains several built-in controls.
For more information, read the [Built-in Control Reference](/docs/tutorials/control-reference-builtin).

### Built-in Controls

#### Forms
+ **Button** - button that triggers the postback
+ **ComboBox** - standard HTML select with advanced binding options
+ **CheckBox** - standard HTML checkbox
+ **LinkButton** - hyperlink that triggers the postback
+ **ListBox** - standard HTML listbox
+ **Literal** - renders a text in the page, supports date and number formatting
+ **RadioButton** - standard HTML radiobutton
+ **TextBox** - HTML input, password or textarea

#### Validation
+ **ValidationMessage** - displays a validation error for particular field
+ **ValidationSummary** - displays all validation errors in the page

#### Collections
+ **DataPager** - displays a list of pages in the grid
+ **GridView** - displays a table grid with sort functionality
+ **Repeater** - repeats a template for each item in the collection

#### Master Pages
+ **Content** - defines a content that is hosted in ContentPlaceHolder
+ **ContentPlaceHolder** - defines a place where the content page is hosted
+ **SpaContentPlaceHolder** - a ContentPlaceHolder which works as a Single Page Application container

#### Other
+ **UpdateProgress** - displays specified content during the postback

&nbsp;

### Common Control Properties

All controls have some properties in common. You can use most of them also on standard HTML elements.

+ **DataContext** - changes the binding context for the content of the control / element.
+ **ID** - specifies an unique id of the control. Be careful - the ID might be different if the control appears several times on the page.
+ **Visible** - hides the control in the page (using CSS display property).

You can also add any HTML attribute to almost all controls. You can also use binding in the HTML attributes.
All attributes used on the DotVVM control will be added to the main HTML element rendered by the control.
