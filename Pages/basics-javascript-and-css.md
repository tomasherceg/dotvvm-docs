## Javascript and CSS Resource Management

**DotVVM** has built-in mechanism for managing reasources. `DotvvmResource` is a class which represents any content that will be 
linked in HTML output, like javascript files or CSS stylesheets. 

The resources are named and stored in a global repository inside the `DotvvmConfiguation` object. 
Resources can also declare their dependencies that will be automatically resolved.
So if you include a library which has several dependent resources, DotVVM will include all of them and in the correct order.


### Resource Repository

All resources are registered in resource respository found in the `DotvvmConfiguration.Resources` collection. 
You can register new resource using `Register` method. Typically, you want to do this in the `Startup.cs` file.

```CSHARP
configuration.Resources.Register("bootstrap-css", new StyleResource()
{
    Url = "~/Content/bootstrap.min.css"
});
configuration.Resources.Register("bootstrap", new ScriptResource()
{
    Url = "~/Scripts/bootstrap.min.js",
    Dependencies = new[] { "bootstrap-css", "jquery" }
});
```

In the code, you can retrieve the resource by its name using `FindResource` method. 

You can also use `dotvvm.js` to register resources.

<!-- TODO: sample -->


### Built-in Resources
Several built-in resources are registered and embedded in **DotVVM.Framework** library by default. 
However, you can overwrite them by your own ones - just call the `Register` method.

* **dotvvm** - a fundamental set of function required by DotVVM to work correctly.
* **dotvvm.validation** - a DotVVM validation framework.
* **dotvvm.fileUpload** and **dotvvm.fileUpload-css** - a helper methods and styles for the FileUpload control.
* **dotvvm.debug** - a helper that displays exception details from the commands.
* **knockout** - Knockout JS 3.2.0
* **jquery** - jQuery 2.1.1

Also, the bootstrap resource is declared, however the Bootstrap files are not included in the **DotVVM.Framework** library.

* **bootstrap** - points to the `~/Scripts/bootstrap.min.js`
* **bootstrap-css** - points to the `~/Content/bootstrap.min.css`

To support client-side number and date formats, there are also automatically generated resources:

* **globalize** - a Globalize.js library
* **globalize:en-US** - a globalization resources for en-US culture. All cultures in .NET Framework are supported, 
however only a subset of the number and datetime formats are supported.


### Requesting Resources

In the page, you can use a **RequiredResource** control to manually link a resource.

```DOTHTML
<dot:RequiredResource Name="bootstrap" />
```

`StyleResource`s are placed in the `head` section, the `ScriptResource`s are placed at the end of the `body` element.

Also, each control in the page can request resources it needs to work properly. For example, if you add the FileUpload control to the page,
the control will call `DotvvmRequestContext.AddRequiredResource` to tell the DotVVM resource manager, that it needs some specific resource.

When the page is about to be rendered, DotVVM resource manager will get all required resources, sort them to satisfy the dependency constraints, 
and renders them into the HTML.


### Resource Options

All resources have the main property `Url` and a collection `Dependencies` where dependent resource names are specified.

Sometimes it may be helpful to embed the resource in some assembly. First, you have to add the file to the assembly and set its Build Action as Embedded Resource.
Then, the resource class has a property `EmbeddedResourceAssembly` - you need to put the assembly name there.
In that case, the `Url` property will not contain the resource URL, but the embedded resource name (e.g. MyAssembly.Folder.SubFolder.FileName.js).

If you want to use CDN for script files, there are also properties `CdnUrl` and `GlobalObjectName`. If they are set, the framework will try to load the 
script from the CDN first and will use the GlobalObjectName to check whether the script was loaded successfully. If not, it will fall back to the `Url` property.

You can of course implement custom resource types. There is also an `InlineScriptResource` which renders the inline javascript.


### Resource Processing

You can register `IResourceProcessor` in the resource repository which can perform additional action with the collection of resources before it's rendered. 
It can be used e.g. for bundling - if you find, that the client request 5 resources and there is a bundle which contain all of them, you can modify 
the collection and make the client to download the bundle.

```CSHARP
var bundling = new BundlingResourceProcessor();
bundles.RegisterBundle(dotvvmConfiguration.Resources.FindNamedResource("myBundle"), "script1", "script2");
dotvvmConfiguration.Resources.DefaultResourceProcessors.Add(bundling);
```