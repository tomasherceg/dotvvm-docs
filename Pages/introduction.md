## Introduction

As a .NET developer, you have several options to write a web app. The official way is to use **ASP.NET MVC** 
or **ASP.NET Web API** in combination with some client-side framework, like _React_, _Angular_ or _Knockout_.  

But when you start writing big enterprise application, you soon discover that there is no ready-made solution for that. 
You have to learn many new things and build quite a lot of infrastructure to make the development convenient. 

You can **build your app really fast** if you have a framework which handles client-server communication, validation, 
SPAs and globalization for you, and which provides plenty of ready-made controls you can use immediately. And that's 
the goal of **DotVVM**.

Also, you don't have to learn twenty javascript libraries and frameworks. You can do most of the stuff with
**only C#, HTML and CSS**. Nothing more!

**DotVVM** is a framework that helps you write modern websites in the MVVM fashion.
**dot** represents **.NET Framework** and **VVM** stands for **MVVM - Model View ViewModel pattern**.



### How Does It Work?

First, you have to write the **view**. We use HTML syntax, but there are some flavors added (we call it _DOTHTML_).
Notice the `{value: Property}` and `{command: Method}` data-bindings and also the custom `dot:Something` elements - these are 
_DotVVM controls_.

```DOTHTML
@viewModel DotvvmDemo.CalculatorViewModel, Dotvvm
    
<p>
    Enter the first number: 
    <dot:TextBox Text="{value: Number1}" />
</p>
<p>
    Enter the second number: 
    <dot:TextBox Text="{value: Number2}" />
</p>
<p>
    <dot:Button Text="Calculate" Click="{command: Calculate()}" />
</p>
<p>
    The result is: {{value: Result}}
</p>
```

Next, we have to write the **viewmodel**. We use plain C# class.

```CSHARP
using System;
    
namespace DotvvmDemo 
{
    public class CalculatorViewModel 
    {
            
        public int Number1 { get; set; }
            
        public int Number2 { get; set; }
            
        public int Result { get; set; }
            
        public void Calculate() 
        {
            Result = Number1 + Number2;
        }
    }
}
```

And that's it! **DotVVM** translates the `dot:TextBox` control into `input type="text"` and `dot:Button` into `input type="submit"`.


The `{value: Number1}` binding is translated to Knockout JS expressions `<input data-bind="value: Number1">`.


The `{command: Function()}` is translated to a javascript call of a `dotvvm.postBack` function. This will serialize the viewmodel in JSON,
send it to the server. On the server, the **Calculate** method is invoked. After it returns, the server will serialize the viewmodel in JSON again
and send it back to the browser. The changes in the viewmodel will then be applied to the controls on the page and the result of the 
arithmetic operation will be displayed.


