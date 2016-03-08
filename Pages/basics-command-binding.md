## Command binding
This type of binding allows you to call a function in the ViewModel on the server. 
Consider the following ViewModel:
```CSHARP
public class MyViewModel {
    ...
    public void MyFunction() {
        ...
    }
    ...
}
```

In the DOTHTML markup you can use the Button control and this binding:
```DOTHTML
<dot:Button Click="{command: MyFunction()}" Text="Submit Form" />
```

If you run the page and view the page source code, you'll see that **DotVVM** translated the binding to a call to a function in **DotVVM.js**.
The DotVVM.js file is included in the page automatically, you don't have to reference it yourself.
```DOTHTML
<input type="button" onclick="dotvvm.postBack(...)" value="Submit Form"/>
```

This function makes AJAX POST request to the server. The request contains the JSON serialized ViewModel. 
When it arrives to the server, the server loads it and executes the function. Then, the ViewModel is serialized back to JSON
and sent to the client's browser. Then, the changes made to the viewmodel on the server, are applied to the page.

The function in the ViewModel can have arguments. If you need to pass e.g. some id to the function, you can - just put the name of 
a property from the ViewModel. 

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

This is quite a complex sample. In the viewmodel, we have a collection of tasks and a method DeleteTask that accepts one integer argument. 
Each Task object has property **Name** and **TaskId**.

In the markup we used the **Repeater** control that takes items from the **Tasks** collection and renders the **ItemTemplate** for each 
item in the collection.

The template renders the Name property as a text in the page. Then, it renders a button that calls the DeleteTask method using 
the **command** binding.

Notice that we use **_parent.DeleteTask**, because the DeleteTask method is not in the `Task` class, but in the `MyViewModel` class. 
The Repeater control switches the _binding context_ on the ItemTemplate, so the bindings are evaluated in the `Task` object context 
and not in the top-level context. 
You can use the following reserved names in **command** and **value** expressions: 
* `_root` goes to the top-level ViewModel object.
* `_parent` goes to the parent context.
* `_parent{#number}` goes to the parent #number times
* `_this` goes to the current context. It is useful only if you want to bind directly to the ViewModel object (e.g. if you want to 
display a collection of strings, or pass current data context to a method): ``{value: _this}``

Then we pass the `TaskId` as a parameter in the `DeleteTask` method. The TaskId is also evaluated in the current binding context, 
not in the function context - if you want to use value from parent, you'd have to use the `_parent.TaskId`.

The command binding is translated to delegate and you can use virtually any C# expression. There are some limitations but simple 
expression should work.
* `MyFunction()`
* `MyFunction(Argument)`
* `MyFunction(Argument.Collection[5].Property * 2)`
* `Property.MyFunction(42, "test")`
* `Collection[3].Property.MyFunction(Argument)`

