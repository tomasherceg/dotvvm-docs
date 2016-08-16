## Code-only Controls

This kind of controls is useful when you need to render a piece of HTML and/or you need to support data-binding and manipulate
with the viewmodel.

### Control Registration

First, you need to register the code-only control in the `DotvvmStartup.cs` file. 

```CSHARP
config.Add(new DotvvmControlConfiguration() 
{ 
    TagPrefix = "cc",
    Namespace = "DotvvmDemo.Controls",
    Assembly = "DotvvmDemo"
});
```

Using this code snippet, if you use the `<cc:` tag prefix, DotVVM will search for the control in the specified namespace and assembly.

### Basics

But let's start with are some basic things. All controls in **DotVVM** derive from `DotvvmControl` class. It provides only 
basic functionality and it is not a good base class to inherit directly for most purposes. 

The most useful class to be derived from is `HtmlGenericControl`. It is prepared to render one HTML element (which can contain
child elements of course). Most built-in controls in **DotVVM** derive from `HtmlGenericControl`. 


### Rendering a TextBox

The best example to learn how to write controls in **DotVVM** is to look how the built-in controls are implemented.
Let's begin with the [TextBox](/docs/controls/builtin/TextBox/{branch}).

The textbox in HTML (with Knockout JS binding) looks like this:

```DOTHTML
<input type="text" data-bind="value: FirstName" />
```

This is what we'd like to render. So let's inherit from `HtmlGenericControl`. In the constructor, we call the base constructor 
and tell the name of the HTML element - in our case we want `input`.

```CSHARP
public class TextBox : HtmlGenericControl
{
    public TextBox() : base("input")
    {

    }
}
```

Now, the `HtmlGenericControl` has 4 methods which we can override to modify the rendered HTML. They are called in this order:

+ **AddAttributesToRender** - by default, this method takes all HTML attributes set to the control, and prepares them to be rendered.

+ **RenderBeginTag** - by default, this method renders the begin tag.

+ **RenderContents** - by default, this method renders the child controls.

+ **RenderEndTag** - by default, this method renders the end tag.

### HtmlWriter

Now, let's see how to render the HTML element. In **DotVVM**, we use the `HtmlWriter` to generate HTML. To render 
the `<input type="text" />` we need something like this:

```CSHARP
    writer.AddAttribute("type", "text");
    writer.RenderSelfClosingTag("input");
```

There are also methods `RenderBeginTag("input")`, `RenderEndTag()`, `WriteText("some text")` or `WriteUnencodedText("some HTML")`.

The `AddAttribute` method is called before rendering the tag and it also has a third argument called `append`. 
If you call `AddAttribute("class", "blue")` and then `AddAttribute("class", "red", true)`, the class will be appended. 

The `HtmlWriter` knows that values in the `class` HTML attribute are separated by spaces, values in the `style` attribute by semicolons etc. You can also specify 
your own separator character as the fourth argument.

### Rendering HTML

Let's continue with the **TextBox** class. We don't want to render begin and end tags, but the self closing one. Also, the control
cannot specify any children, so we should override the **RenderContents** method to not render anything.

```CSHARP
protected override void RenderBeginTag(IHtmlWriter writer, IDotvvmRequestContext context)
{   
    // TagName contains the value passed to the base constructor. 
    // We don't want to call base.RenderBeginTag here because it would render the begin tag and then the closing tag.
    // We want the self closing tag. 
    
    writer.RenderSelfClosingTag(TagName); 
}

protected override void RenderContents(IHtmlWriter writer, IDotvvmRequestContext context)
{   
    // do nothing, textbox cannot contain anything
}

protected override void RenderEndTag(IHtmlWriter writer, IDotvvmRequestContext context)
{    
    // do nothing, we have already rendered the self-closing tag
}
```

However, the most interesting will be the `AddAttributesToRender` method. The default implementation takes
all HTML attributes that are not properties, and add them to the `HtmlWriter`. So, if the user uses the following snippet,
the default implementation of `AddAttributesToRender` will add the `class`, `style` and `placeholder` attributes 
to the `HtmlWriter`. 

It even supports data-bindings, so you don't have to care about this. You just need to take care of the control properties.

```DOTHTML
<dot:TextBox Text="{value: FirstName}" style="border: none" class="txb1" placeholder="Enter first name" />
```

We need to declare the `Text` property first:

```CSHARP
public string Text
{
    get { return Convert.ToString(GetValue(TextProperty)); }
    set { SetValue(TextProperty, value); }
}
public static readonly DotvvmProperty TextProperty =
    DotvvmProperty.Register<string, TextBox>(t => t.Text, "");
```

However, we should support two scenarios:

```DOTHTML
<dot:TextBox Text="{value: FirstName}" />
<dot:TextBox Text="Test" />
```

In the first case, we need to render `data-bind="value: FirstName"`, in the second case we need to render `value="Test"`.
We can solve this by a simple if:

```CSHARP
protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
{
    var textBinding = GetValueBinding(TextProperty);
    if (textBinding != null) 
    {
        // the property contains binding - this will render data-bind="value: expression"
        writer.AddKnockoutDataBind("value", this, TextProperty);
    }
    else 
    {
        // render the value in the HTML
        writer.AddAttribute("value", Text);
    }

    writer.AddAttribute("type", "text");
    
    base.AddAttributesToRender(writer, context);
}
```

Because this pattern is quite usual an in most controls you would have written the `if` statement checking the presence
of binding and rendering the appropriate output, there is an overload of the `AddKnockoutDataBind` method with four arguments.
It allows you to specify a function which is called when the specified property doesn't contain a binding.

So we could simplify the function above like this:

```CSHARP
protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
{
    writer.AddKnockoutDataBind("value", this, TextProperty, () => {
        writer.AddAttribute("value", Text);
    });

    writer.AddAttribute("type", "text");
    
    base.AddAttributesToRender(writer, context);
}
```
