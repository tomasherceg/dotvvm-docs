## Master Pages

In most web applications, you need all pages to have common header, menu and footer. **DotVVM** solves this by using **Master Pages**. 
If you are familiar with ASP.NET WebForms, the concept of master pages is the same.

There is a **master page** that contains the common parts and it also defines one or more **content place holders**. 

<img src="/Views/Docs/Pages/basics-master-pages-img1.png" alt="Master Page Schema" />

Then, there is one or more **content pages** that define one or more **contents**. These contents will be embedded in the 
corresponding **place holders** in the master page. The content page also specifies which master page it is nested in using 
the `@masterPage` directive at the top of the file.


### Notes

It is not possible to make a HTTP request to the master page, therefore should not be registered in the _Startup.cs_. 
Only content pages can receive HTTP requests. 

You can also nest a master page to another master page and so on - just add the `@masterPage` directive to the master page.

Also note that the master page must also specify the `@viewmodel` directive. It doesn't have to be a class, it can be an interface.
In most cases, _the viewmodel of the masterpage is a common base class for all content page viewmodels_. 

The **ContentPlaceHolder** control can have a default content - if the content page has no **Content** with the corresponding ID,
the default content is used.

```DOTHTML
    <dot:ContentPlaceHolder ID="OptionalContent">
        This will be visible if there is no dot:Content with ContentPlaceHolderID="OptionalContent" in the content page.
    </dot:ContentPlaceHolder>
```

The recommended extension for master pages is `.dotmaster`, because you can simply distinguish pages from master pages. 
If you use another extension, not all features of the Visual Studio extension are going to work properly.



### How to Create the Master Page

All you have to do is to choose **DotVVM Master Page** in the New Item dialog.

<img src="/Views/Docs/Pages/basics-master-pages-img2.png" alt="Creating a Master Page" />

Next, the same window for choosing the viewmodel will appear. If you already have a base class viewmodel for the master page,
just uncheck the _Create ViewModel_ option.
Make sure that the master page specifies the correct viewmodel - if not, delete the directive and the IntelliSense will help you
to pick the correct class.

<img src="/Views/Docs/Pages/basics-master-pages-img3.png" alt="Picking the correct class" />

Finally, write your HTML code. On a place where you need to embed something from a content page, declare a **ContentPlaceHolder**.

```DOTHTML
<dot:ContentPlaceHolder ID="SomeId">
</dot:ContentPlaceHolder>
```

Most master pages need only one or two of them, however you can use as many ContentPlaceHolders as you need. 


### How to Create the Content Page

Creating the content page is very similar. Just add a new **DotVVM Page** and in the dialog window, tick the **Embed in Master Page** checkbox.
Then, pick the correct master page.

<img src="/Views/Docs/Pages/basics-master-pages-img4.png" alt="Embedding a page in the master page" />

The wizard will generate the **Content** controls automatically based on **ContentPlaceHolders** present in the selected master page.

> Don't forget! The master page's viewmodel should be a base class of the content page viewmodels.