## Binding Syntax

One of the most interesting and powerful things in **DotVVM** is the data binding. The magic of writing "javascript apps" in C#
is the ability to translate C# lambda expressions to javascript. 

All data bindings are strongly typed, dynamic types are not currently supported. Therefore, each master page has to specify the viewmodel
class or an interface, because we have to be able to compile those bindings and map them to a correct type.

&nbsp;

There are several types of data binding in **DotVVM**. 

* **{value: Property}** - picks the value of a specified property from the viewmodel.
* **{command: Function()}** - executes the specified function in the viewmodel.
* **{resource: ResourceFile.ResourceKey}** - gets the resource entry value from the specified RESX file.

There are also _controlCommand_ and _controlProperty_ bindings. They are intended to be used by control developers and they are described
in the [Markup Controls](/docs/tutorials/control-development-markup-controls) page.


### Usage

We can use data binding almost everywhere in the DOTHTML. The databinding connects the View (DOTHTML markup) with the ViewModel. 
The databinding uses the following syntax: 
```DOTHTML
<element property="{bindingType: bindingExpression}" />
```
There are several binding types, the most common are **value** and **command** bindings. The binding expression is a piece of C# 
code (however there are many restrictions).
If you want to use the binding not as a value of attribute, you have to use double curly braces. This is because of `<script>` 
and `<style>` elements that can appear in the page and where the curly braces have special meaning.
```DOTHTML
...some text {{bindingType: bindingExpression}} some text...
```

It is not possible to use the binding in the attribute value when another content is there:
```DOTHTML
<!-- this is not considered as a binding !!! -->
<element property="something {bindingType: bindingExpression}" />
```

