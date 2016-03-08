## Resource Binding

This binding is used to access values from resource files. The default syntax is `{resource: FullNamespace.ResourceClass.ResourceKey}`. 
This will find the appropriate class and use the value with the specified key.

If you have a project named *MyWebApp* and you have a *Resources\Web\Strings.resx* file, then the resource class will 
be *MyWebApp.Resources.Web.Strings* (provided you haven't change the default namespace in the project properties). 

Because this syntax is quite long, there are two ways on how to make it shorter.

### @resourceType Directive

Using the **@resourceType** directive on the page, you can specify the default resource class that is being used.

```DOTHTML
@resourceType MyWebApp.Resources.Web.Strings, MyWebApp

{{resource: ResourceKey}}
```

You can only put the resource key in the binding. Of course you can still use the full specification or resource to retrieve 
the value from a different RESX file than that one specified in the @resourceType directive.

This way is quite convenient if most of the resource bindings in the page uses one resource class.

### @resourceNamespace Directive

If you have multiple resource files you want to use in the page, the better way is to use **@resourceNamespace** directive.
You only specify the namespace in which the resource classes will be looked for.

Consider a project with the *Resources\Web\Strings1.resx* and *Resources\Web\Strings2.resx* files. The markup can look like this:

```DOTHTML
@resourceNamespace MyWebApp.Resources.Web

{{resource: Strings1.SomeResource}}
{{resource: Strings2.SomeResource}}
```

<br />

The bindings are always evaluated on the server. When evaluating, the current thread culture will be used. See the 
[Globalization](/docs/tutorials/basics-globalization) section for more information.

