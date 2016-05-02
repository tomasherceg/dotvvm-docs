## Master Pages

In most web apps, you need all pages to share the header, menu and footer. **DotVVM** supports a thing called **Master Pages**. 
If you are familiar with _ASP.NET WebForms_, the concept of master pages is exactly the same.

We have two kinds of pages:

1. The **Master Page** has the `.dotmaster` extension. It contains the whole layout of the page including the `<html>`, `<head>` and `<body>` tags.
The master page contain one or more `<dot:ContentPlaceHolder>` controls.     

2. The **Content Pages** have the `.dothtml` extension and contains one or more `<dot:Content>` elements with content. This content will be embedded
in the corresponding `ContentPlaceHolder`s in the master page.  

<p><img src="{imageDir}basics-master-pages-img1.png" alt="Master Page Schema" /></p>

If you want to use the master page, you have to add the `@masterPage` directive at the top of the file.


### Notes

It is not possible to make a HTTP request to the master page, therefore it should not be registered in the _Startup.cs_. 
Only content pages can receive HTTP requests. 

You can also nest a master page in another master page and so on - just use the `@masterPage` directive in the master page.

Also note that even the master page must specify the `@viewmodel` directive. It doesn't have to be a class, it can be an interface. This is because the
framework needs to know the type that will be used in the bindings in the page. 

In most cases, _the viewmodel of the masterpage is a common base class for viewmodels of the content pages_. 

The `<dot:ContentPlaceHolder>` doesn't have to be empty. If the content page has no corresponding `<dot:Content>` for any placeholder,
its content will be used.

```DOTHTML
    <dot:ContentPlaceHolder ID="OptionalContent">
        This will be visible if there is no dot:Content with ContentPlaceHolderID="OptionalContent" in the content page.
    </dot:ContentPlaceHolder>
```

### How to Create the Master Page

All you have to do is to choose **DotVVM Master Page** in the New Item dialog.

<p><img src="{imageDir}basics-master-pages-img2.png" alt="Creating a Master Page" /></p>

Next, the same window for choosing the viewmodel will appear. If you already have a base class viewmodel for the master page,
just uncheck the _Create ViewModel_ option.
Make sure that the master page specifies the correct viewmodel - if not, delete the directive and the IntelliSense will help you
to pick the correct class.

<p><img src="{imageDir}basics-master-pages-img3.png" alt="Picking the correct class" /></p>

Finally, write your HTML code. On a place where you need to embed something from a content page, declare a **ContentPlaceHolder**.

```DOTHTML
<dot:ContentPlaceHolder ID="SomeId">
</dot:ContentPlaceHolder>
```

Most master pages need only one or two of them, however you can use as many `ContentPlaceHolder`s as you need.

> The [DotVVM Pro for Visual Studio 2015](/products/dotvvm-pro-for-vs-2015) has the IntelliSense for the `ContentPlaceHolderId` property and much more. 


### How to Create the Content Page

Creating the content page is very similar. Just add a new **DotVVM Page** and in the dialog window, tick the **Embed in Master Page** checkbox.
Then, pick the correct master page.

<p><img src="{imageDir}basics-master-pages-img4.png" alt="Embedding a page in the master page" /></p>

The wizard will generate the **Content** controls automatically based on **ContentPlaceHolders** present in the selected master page.

> Don't forget! The viewmodel in the content page must derive or implement from the viewmodel in the master page.
