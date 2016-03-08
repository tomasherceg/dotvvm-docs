## Code-only Controls

This kind of controls is useful when you need to generate an exact piece of HTML and/or you need to use databinding and manipulate
with the viewmodel.

First, you need to register the code-only controls in the `dotvvm.json` file. If the section markup/control doesn't already exist, add it:

```JSON
{
  "markup": {
    "controls": [
      ...
      { "tagPrefix": "cc", "namespace": "MyAssembly.MyNamespace", "assembly": "MyAssembly" }
    ]
  }
}
```

But let's start with are some basic things. All controls in **DotVVM** derive from `DotvvmControl` class. It provides really the 
basic functionality and it is not a good base class to inherit directly for most purposes. 

The most useful class to be derived from is `HtmlGenericControl`. It is prepared to render one HTML element (which can contain
child elements of course). Most controls in **DotVVM** derive from this control. 


### Rendering a TextBox

The best example to learn how to write controls in **DotVVM** is to look, how the standard ones are implemented.
Let's begin with **TextBox**.

The textbox in HTML (with Knockout JS binding) looks like this:

```DOTHTML
<input type="text" data-bind="value: FirstName" />
```

This is what we'd like to render. So let's inherit from `HtmlGenericControl`. In the constructor, we call the base constructor 
and tell the name of the HTML element - in our case it's "input".

```CSHARP
public class TextBox : HtmlGenericControl
{
    public TextBox() : base("input")
    {

    }
}
```

Now, the **HtmlGenericControl** has 4 methods which we can override to modify the stuff that is rendered. They are called in this order:
+ **AddAttributesToRender** - by default, this method takes all attributes set to the control, and prepares them to be rendered.
+ **RenderBeginTag** - by default, this method renders the begin tag.
+ **RenderContents** - by default, this method renders the child controls.
+ **RenderEndTag** - by default, this method renders the end tag.

Now, let's see how to render a HTML element. In **DotVVM** we use the class **IHtmlWriter** to generate HTML. To render 
the `<input type="text" />` we need something like this:

```CSHARP
    writer.AddAttribute("type", "text");
    writer.RenderSelfClosingTag("input");
```

There are also methods **RenderBeginTag("input")**, **RenderEndTag()**, **WriteText("some text")** or **WriteUnencodedText("some HTML")**.

The **AddAttribute** method is called before rendering the tag and it also has a third argument called "append". 
If you call **AddAttribute("class", "blue")** and then **AddAttribute("class", "red", true)**, the class will be appended. 

The **IHtmlWriter** knows that **class** is separated by space, **style** by semicolon etc. You can also specify your own separator character
as the fourth argument.

&nbsp;

Let's continue with the **TextBox** class. We don't want to render begin and end tag, but the self closing one. Also, the control
cannot specify any children, so we should override the **RenderContents** method to not render anything.

```CSHARP
protected override void RenderBeginTag(IHtmlWriter writer, RenderContext context)
{   
    // TagName contains the value passed to the base constructor. 
    // We don't call base.RenderBeginTag here because it would render the begin tag
    writer.RenderSelfClosingTag(TagName); 
}

protected override void RenderContents(IHtmlWriter writer, RenderContext context)
{   
    // do nothing 
}

protected override void RenderEndTag(IHtmlWriter writer, RenderContext context)
{    
    // do nothing
}
```

However, the most interesting will be the **AddAttributesToRender** method. The default implementation takes
all HTML attributes that are not properties, and add them to the **IHtmlWriter**. So, if the user uses the following snippet,
the default implementation of AddAttributesToRender will add the **class**, **style** and **placeholder** attributes 
to the **IHtmlWriter**. It even supports data-bindings, so you don't have to care about this. You just need to take care 
of the control properties.

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
We can solve this by simple if:

```CSHARP
protected override void AddAttributesToRender(IHtmlWriter writer, RenderContext context)
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

Because this pattern is quite usual an in most controls you would have written the **if** statement checking the presence
of binding and rendering the appropriate output, there is an overload of **AddKnockoutDataBind** function with fourth argument.
It is a function which is called when the specified property doesn't contain a binding.

So we could simplify the function above like this:

```CSHARP
protected override void AddAttributesToRender(IHtmlWriter writer, RenderContext context)
{
	writer.AddKnockoutDataBind("value", this, TextProperty, () => {
		writer.AddAttribute("value", Text);
	});

    writer.AddAttribute("type", "text");
    
    base.AddAttributesToRender(writer, context);
}
```
