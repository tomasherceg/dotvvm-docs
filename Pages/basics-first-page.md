## Creating the First Page

Every page in **DotVVM** consists of a **view** and a **viewmodel**. 

To create a page, just right-click the desired folder in the Solution Explorer and choose **Add / New Item...**.
In the dialog, navigate to the Web / DotVVM section and choose the **DotVVM Page** template.

<img src="/Views/Docs/Pages/basics-first-page-img1.png" alt="Adding a new page" />

After you set the name of the page, another window will appear. In this window, you can specify whether you want 
to create a viewmodel and where it should be placed.

<img src="/Views/Docs/Pages/basics-first-page-img2.png" alt="Creating the viewmodel" />

After you confirm the selection, the view and the viewmodels are added to the project.


### View

The **view** is a file with `.dothtml` extension. The views in DotVVM use standard HTML syntax with three special flavors:

* **Directives** are placed at the top of the file and they declare some page related information.
There is only one directive which is mandatory and must be present in each .dothtml file:

```DOTHTML    
    @viewModel Namespace.ClassName, Assembly
```

* **DotVVM Control Elements** are standard HTML elements with a namespace prefix. These prefixes are not registered using 
the xmlns attributes, DotVVM looks at the `dotvvm.js` file for registered namespaces instead.
Each DotVVM control can specify several properties which are mapped to the element attributes or child elements.

```DOTHTML
    <dot:Repeater DataSource="..." style="display: none">
        <ItemTemplate>
            some content...
        </ItemTemplate>
    </dot:Repeater>
```

In the code sample above you can see the **Repeater** control. It has a **DataSource** property specified as an attribute
and the **ItemTemplate** property which is inside the dot:Repeater element. Whether the property is used as an
attribute or as an child element, is decided by the developer of the control. The Visual Studio extension supports IntelliSense
and it will tell you whether the property should be an attribute or an element.

If you want to apply any other HTML attribute to a control, you can do it - see the **style** declaration in the example. The most
common case is to add **class** attribute to the control to apply custom look &amp; feel.



### ViewModel

The **viewmodel** is a standard C# class which is referenced in the `.dothtml` file. Any .NET class can be the viewmodel, but there is
one thing to remember.

> The DotVVM viewmodel must be JSON-serializable. To make everything work properly, we recommend to use only public properties and public methods.

We recommend that the viewmodel derive from the `DotVVM.Framework.ViewModel.DotvvmViewModelBase` class. It has a handy property **Context** 
which will allow to interact with the HTTP request information, perform redirects and other things you may need.

There are also **Init**, **Load** and **PreRender** methods you can override to perform tasks in specific state of the request processing.
You can find more information in the [ViewModels](/docs/tutorials/basics-viewmodels) tutorial.

