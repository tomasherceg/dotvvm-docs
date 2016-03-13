## Creating the First Page

Every page in **DotVVM** consists of a **view** and a **viewmodel**. 

To create a page, just right-click the desired folder in the Solution Explorer window and choose **Add / New Item...**.
In the dialog, navigate to the Web / DotVVM section and choose the **DotVVM Page** template.

<img src="{imageDir}/basics-first-page-img1.png" alt="Adding a new page" />

After you enter the name of the page and confirm the selection, another window will appear. In this window, you can specify whether you want 
to create a viewmodel or not, and where it should be placed.

<img src="{imageDir}/basics-first-page-img2.png" alt="Creating the viewmodel" />

After you proceed, the view and the viewmodels are added to the project. If you place your views in the **Views** folder in your project,
the window will automatically place your viewmodel in the **ViewModels** folder.


### View

The **view** is a file with `.dothtml` extension. The views in DotVVM use standard HTML syntax with two enhancements:

* **Directives** are placed at the top of the file. They define some page related information.
There is only one directive which is mandatory and must be present in each `.dothtml` file:

```DOTHTML    
    @viewModel Namespace.ClassName, Assembly
```

* **DotVVM Controls** are standard HTML elements with a namespace prefix. These prefixes are not registered using 
the xmlns attributes like in XML. Instead, DotVVM looks in its configuration class (`DotvvmStartup`) for registered namespaces instead.
Each DotVVM control can specify several properties which are specified using attributes or child elements.

```DOTHTML
    <dot:Repeater DataSource="..." style="display: none">
        <ItemTemplate>
            some content...
        </ItemTemplate>
    </dot:Repeater>
```

In the code sample above you can see the **Repeater** control. It has a **DataSource** property specified as an attribute
and the **ItemTemplate** property which is inside the `dot:Repeater` element. Whether the property is used as an
attribute or as an child element, is decided by the developer of the control. The DotVVM for Visual Studio extension supports IntelliSense
and it will tell you which controls and properties are available.

If you want to apply any other HTML attribute to a control, you can do it on most of the controls. Notice the **style** attribute applied to the 
**Repeater** contron in our example. The most common use case for this is adding a **class** attribute to some control.



### ViewModel

The **viewmodel** is a standard C# class which is referenced in the `.dothtml` file using the **@viewModel** directive. Any .NET class can 
be the viewmodel, but there is one thing to remember.

> The DotVVM viewmodel class must be JSON-serializable. To make everything work properly, we recommend to use only public properties and public methods.
Don't launch rockets in space in your getters, setters and constructor(s) because it will be executed several times during the JSON serialization.

We recommend that your viewmodels derive from the `DotVVM.Framework.ViewModel.DotvvmViewModelBase` class. This class contains a property **Context** 
which will allow you to interact with the HTTP request, e.g. do a redirect to another page or route.

The `DotvvmViewModelBase` class also has the **Init**, **Load** and **PreRender** methods. You can override them to perform tasks in specific state of
the request execution. You'll find more information about them in the [ViewModels](/docs/tutorials/basics-viewmodels) tutorial.

