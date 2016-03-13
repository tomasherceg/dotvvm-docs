## Binding Syntax

One of the most interesting and powerful things in **DotVVM** is the data binding. The magic of writing "javascript apps" in C#
is the ability to translate binding expressions to javascript. 

All data bindings are **strongly typed** and compiled before the page is loaded the first time. Currently, dynamic types are not supported. 
Therefore, each master page has to specify the viewmodel class or an interface, because we have to be able to compile those bindings and 
map them to a correct type.

There are several types of data binding in **DotVVM**. 

* `{value: Property}` - picks the value of a specified property from the viewmodel.
* `{command: Function()}` - executes the specified function in the viewmodel.
* `{resource: ResourceFile.ResourceKey}` - gets the resource entry value from the specified RESX file.

There are also _controlCommand_ and _controlProperty_ bindings. They are intended to be used by control developers and they are described
in the [Markup Controls](/docs/tutorials/control-development-markup-controls/{branch}) section.

> The [DotVVM Pro for Visual Studio 2015](/products/dotvvm-pro-for-vs-2015) has the IntelliSense for expressions in all types of bindings. 



### Usage

We can use data binding almost everywhere in the DOTHTML. The databinding transfers the data between the View (DOTHTML markup) and the ViewModel. 

The databinding uses the following syntax:
 
```DOTHTML
<element property="{value: bindingExpression}" />
```

There are several binding types, the most common are **value** and **command** bindings. The binding expression is a piece of code in a language 
similar to C# (with some restrictions and some enhancements).

If you want to use the binding in the page text, you have to use double curly braces. This is because of `<script>` 
and `<style>` elements in which the curly braces have special meaning.

```DOTHTML
...some text {{value: bindingExpression}} some text...
```

It is not possible to use the binding in the attribute value when another content is there:

```DOTHTML
<!-- this does not work - the binding must be whole attribute value !!! -->
<element property="something {value: bindingExpression}" />
```

