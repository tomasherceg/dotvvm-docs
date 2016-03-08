## Introduction

SPAs and websites with client-side frameworks like _Angular_ or _Knockout JS_ are very popular these days.
There are many samples how to combine Angular or Knockout with _ASP.NET Web API_. 


But when you start writing big enterprise application with just Angular and Web API, you soon discover that 
you have to write plenty of infrastructure code in C# and plenty of dull code in Javascript which does 
nothing spectacular. It just calls the API and updates the UI.


Having a solid foundation where the API communication and other stuff like validation and localization is already taken care of,
and having a rich set of ready-made controls, would allow you to **build your app really fast**. And this's the goal of **DotVVM**.


Also, you don't have to learn dozens of javascript libraries and frameworks. You can do most of the stuff with
**only C#, HTML and CSS**. Nothing more!


**DotVVM** is a framework that helps you write modern websites in the MVVM fashion.
**dot** represents **.NET Framework** and **VVM** stands for **MVVM - Model View ViewModel pattern**.



### How Does It Work?

First, you have to write the **view**. We use HTML syntax, but there are some flavors added.
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


The `{command: Function()}` is translated to a javascript call of a `dotvvm.postBack` function which will serialize the viewmodel into JSON,
send it to the server and invoke the **Calculate** method on the server. After the method returns, the server will serialize the viewmodel and
send it back to the browser. The changes in the viewmodel will then be applied to the controls on the page.


