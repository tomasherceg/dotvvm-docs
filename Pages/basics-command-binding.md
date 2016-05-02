## Command Binding

This type of binding allows to call a function in the ViewModel on the server.
 
Consider the following ViewModel:

```CSHARP
public class MyViewModel {
    ...
    public void Submit() {
        ...
    }
    ...
}
```

Please note that the method must be public and should not return anything. If you plan to have an async code inside the method, it can be async and return a `Task`.
In some cases, this helps the performance of the application because the web server can reuse waiting threads to process other requests.

In the DOTHTML markup, you can use the [Button](/docs/controls/builtin/Button/{branch}) control and this command binding:

```DOTHTML
<dot:Button Click="{command: Submit()}" Text="Submit Form" />
```

If you run the page and view the page source code, you'll see that **DotVVM** translated the binding to a call to a function in **DotVVM.js**.
The DotVVM.js file is included in the page automatically and contains the whole javascript part of DotVVM. You don't have to reference this file yourself.

```DOTHTML
<input type="button" onclick="dotvvm.postBack(...)" value="Submit Form"/>
```

This function makes an AJAX HTTP POST request to the server. The request contains the JSON serialized ViewModel. 
When it arrives to the server, the server loads it and invokes the function. Then, the ViewModel is serialized back to JSON
and sent to the client's browser. After that, the changes made to the viewmodel on the server are applied to the page.

The function in the ViewModel can have any number of arguments. If you need to pass anything in the function, you can - just put the name of 
a property from the ViewModel or a constant value. 

### Task List Sample

```CSHARP
public class MyViewModel {
    ...
    public List<Task> Tasks { get; set; }
    public void DeleteTask(int taskId) {
        ...
    }
    ...
}
public class Task {
    public int TaskId { get; set; }
    public string Name { get; set; }
}
```

```DOTHTML
<dot:Repeater DataSource="{value: Tasks}">
    <ItemTemplate>
        <p>
            {{value: Name}}
            <dot:Button Click="{command: _parent.DeleteTask(TaskId)}" Text="Delete" />
        </p>
    </ItemTemplate>
</rw:Repeater>
```

This is quite a complex sample. In the viewmodel, we have a collection of tasks and a `DeleteTask` method which accepts one argument of type `int`. 
Each `Task` object has the `Name` and `TaskId` properties.

In the markup, we have used the [Repeater](/docs/controls/builtin/Repeater/{branch}) control which takes items from the `Tasks` collection in the viewmodel 
and renders its `<ItemTemplate>` for each item in this collection.

The template renders the `Name` property as a text in the page. Then, it renders a button that calls the `DeleteTask` method using the **command** binding.

Notice that we use **_parent.DeleteTask**, because the `DeleteTask` method is not declared in the `Task` class, but in the `MyViewModel` class.
 
That's because the `<dot:Repeater>` control switches the [binding context](/docs/tutorials/basics-binding-context/latest/{branch}). 
All bindings in the `<ItemTemplate>` are evaluated in the context of current item from the `Tasks` collection.
 
### Binding Context Variables
 
You can use the following reserved names in **command** and **value** expressions:
 
* `_root` goes to the top-level ViewModel object.
* `_parent` goes to the parent [binding context](/docs/tutorials/basics-binding-context/latest/{branch}).
* `_parent{#number}` goes to the parent #number times
* `_this` goes to the current context. It is useful only if you want to bind directly to the ViewModel object (e.g. if you want to 
display a collection of strings, or pass current binding context to a method): `{value: _this}`

Notice that we pass the `TaskId` as a parameter in the `DeleteTask` method. The `TaskId` is evaluated in the binding context of the `<ItemTemplate>`, 
not in the context of the function - if you want to use value from parent, you would have to use the `_parent.TaskId`.

### Supported Expressions

* `MyFunction()`
* `MyFunction(Argument)`
* `MyFunction(Argument.Collection[5].Property * 2)`
* `Property.MyFunction(42, "test")`
* `Collection[3].Property.MyFunction(Argument)`

