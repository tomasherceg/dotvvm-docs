## Static Command Binding

If you use a [command binding](/docs/tutorials/basics-command-binding/{branch}), the viewmodel is serialized and sent to the server where the 
method is executed. The problem is that the viewmodel can be too large and it wouldn't be really efficient to transfer it to the server and back.
Despite the fact you have some options to specify, which properties will be transferred in each way, sometimes you just need to send one integer to 
the server and receive a simple answer. For these cases we have **static commands**.

A **static command** allows to call a static method on the server without trasmitting the whole viewmodel.
You can pass any arguments to the method and the method can return a result. You can assign the result to some property in the viewmodel.

First, you have to declare a method in your viewmodel. The method must be static and can accept any number of arguments (the only requirement
is that they must be JSON-serializable). It can optionally return a result.

```CSHARP
[AllowStaticCommand]
public static string MyMethod(string name)
{
    // ...
    return result;
}
```

The method must be marked with the `AllowStaticCommand` attribute. That's because the static command can call any static method
and pass any arguments to it. We need to be sure that you really want to allow anyone to call this method.

> Be careful. There is no way for DotVVM to determine whether the arguments passed to the command weren't tampered with. 
Always validate that the values are correct and that the user has appropriate permissions to perform the operation. 

<br />

The binding in the page looks like this:

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: MyClass.MyMethod(Name)}" />
```

Also, you may want to use the method result to update some viewmodel property.

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: SomeProperty = MyClass.MyMethod(Name)}" />
```

<br />

You may also execute simple operations on the viewmodel without making any communication with the server (if you don't call any function in the binding). 

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: SomeProperty = 'Hello ' + Name + '!'}" />
```

Only simple expressions are supported here - see the [Value Binding](/docs/tutorials/basics-value-binding/{branch}) section for more information.
