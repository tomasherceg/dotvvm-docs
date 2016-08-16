## Value Binding

This binding allows you to bind a property in the ViewModel with some control's property in the DOTHTML file, or just render it as a text.
 
Let's have the following ViewModel:

```CSHARP
public class MyViewModel {
    ...
    public string Url { get; set; }
    ...
}
```

In the DOTHTML markup, you can bind the property for example to the hyperlink:

```DOTHTML
<a href="{value: Url}">Go To URL</a>
```

If you run the page and view the page source code, you'll see that DotVVM translated the binding into a Knockout JS expression. DotVVM uses this 
popular framework to do the data-binding.
 
This is the HTML that is rendered to the client:

```DOTHTML
<a data-bind="attr: { 'href': Url }">Go To URL</a>
```

The word **value** indicates the type of the binding - value binding in this case. **Url** is an expression that will be evaluated in the client's browser.
The expression can only use public properties, access collection elements and use several supported operators. 
You cannot, for example, call functions from the value binding.

### Supported Expressions

* `SomeProperty`

* `SomeProperty.OtherProperty`

* `SomeCollection[6]`

* `SomeCollection[6].OtherProperty`

* `SomeProperty >= 0`

* `SomeProperty ? "active" : ""`

* `SomeProperty != OtherProperty`

If you use the `ICollection.Count` and `Array.Length` property, they are correctly translated to javascript - 
they simply call `length` on the javascript array.

_You don't have to be afraid of null values - if a part of the expression evaluates to null, the rest is not evaluated and the result of the evaluation is null. Internally, we treat every `.` as `.?` in C# 6._

### Double and Single Quotes

Because the bindings can be used in HTML attributes which are often wrapped in double quotes, DotVVM allows to use single quotes (apostrophes) for strings as well.

```DOTHTML
<a class="{value: Active ? 'active' : 'not-active' }"></a>
```

### Enums

If you have a property of enum type in your viewmodel, you may need to work with that value in the binding. Please note that enum values are converted to
string on the client side, so you can compare the value with strings.

```CSHARP
public class MyViewModel {
    ...
    public ButtonColor Color { get; set; }    // ButtonColor is enum
    ...
}
```

Use strings for enum value literals:

```DOTHTML
<a class="{value: Color == 'Red' ? 'button-red' : 'button-normal'}">button</a>
```
