## Static Command Binding

Static commands allow to call a method on the server without trasmitting the whole viewmodel to the server and back to the client.
You can pass any arguments to the method and the method can return a result which you can use to update some property in the viewmodel.

First, you have to declare a method in your viewmodel. The method must be static and can accept any number of arguments (the only requirement
is that they must be JSON-serializable). It can return a result.

```CSHARP
[AllowStaticCommand]
public static string MyMethod(string name)
{
    // ...
    return result;
}
```

The method must be marked with the **AllowStaticCommand** attribute. That's because the static command can call any static method
and pass any arguments to it. We want to be sure that you want to allow this method to be called using a static command.

> Be careful. There is no way for DotVVM to determine whether the arguments passed to the command weren't tampered with. 
Always validate that the values are correct, that the current user has appropriate permissions to perform the operation. 

<br />

The binding in the page looks like this:

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: MyMethod(Name)}" />
```

Also, you may want to use the method result to update some viewmodel property.

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: SomeProperty = MyMethod(Name)}" />
```

<br />

You may also execute simple operations on the viewmodel without making any communication with the server. 

```DOTHTML
<dot:Button Text="Something" Click="{staticCommand: SomeProperty = 'Hello ' + Name + '!'}" />
```

Only really simple expressions are supported here - see the [Value binding](/docs/tutorials/basics-value-binding) section for more information.