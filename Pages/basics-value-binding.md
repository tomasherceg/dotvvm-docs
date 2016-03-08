## Value Binding

This binding allows you to bind a property in the ViewModel with some control's property in the DOTHTML file, or just render it in the text. 
Consider the following ViewModel:
```CSHARP
public class MyViewModel {
    ...
    public string Url { get; set; }
    ...
}
```

In the DOTHTML markup you can bind the property to the hyperlink:
```DOTHTML
<a href="{value: Url}">Go To URL</a>
```

If you run the page and view the page source code, you'll see that DotVVM translated the binding to KnockoutJS. 
This is the HTML that goes to the client:
```DOTHTML
<a data-bind="attr: { 'href': Url }">Go To URL</a>
```

**value** means that this is a value binding. **Url** is the expression that is evaluated in the ViewModel.
The expression can only use public properties, access collection elements and there are several operators that are allowed. 
You cannot call functions from the value binding.

Allowed expressions:
* `SomeProperty`
* `SomeProperty.OtherProperty`
* `SomeCollection[6]`
* `SomeCollection[6].OtherProperty`
* `SomeProperty >= 0`
* `SomeProperty ? "active" : ""`
* `SomeProperty != OtherProperty`

If you use the `ICollection.Count` and `Array.Length` property, they are correctly translated to javascript - 
they simply call `length` on the javascript value.

_You don't have to afraid of null values - if a part of the expression evaluates to null, the rest is not evaluated and the result 
of the evaluation is null. Internally, we treat every `.` as `.?` in C# 6._

