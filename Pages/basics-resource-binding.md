## Resource Binding

This type of binding is used to access values from .NET resource files (RESX). The default syntax is `{resource: FullNamespace.ResourceClass.ResourceKey}`. 
This finds the appropriate RESX file and use the value with the specified key.

For example, if you have a project named *MyWebApp* and you have a *Resources\Web\Strings.resx* file in the project, the resource class will 
be *MyWebApp.Resources.Web.Strings* (provided you haven't change the default namespace in the project properties). To retrieve the resource, you need
to use `{resource: MyWebApp.Resources.Web.String.SomeResourceKey}`

Because this syntax is quite long, there are two ways on how to make it shorter.

### @resourceType Directive

Using the `@resourceType` directive on the page, you can specify the default resource class. Then, you can only put the resource key in the binding.

```DOTHTML
@resourceType MyWebApp.Resources.Web.Strings, MyWebApp

{{resource: ResourceKey}}
```

Of course you can still use the full specification or resource to retrieve the value from a different RESX file than that one specified 
in the @resourceType directive.

This way is quite convenient if most of the resource bindings in the page comes from resource class.

### @resourceNamespace Directive

If you have multiple resource files you want to use in the page, the better way is to use **@resourceNamespace** directive.
You only specify the namespace in which the resource classes reside.

For example, in a project with the *Resources\Web\Strings1.resx* and *Resources\Web\Strings2.resx* files, the markup can look like this:

```DOTHTML
@resourceNamespace MyWebApp.Resources.Web

{{resource: Strings1.SomeResource}}
{{resource: Strings2.SomeResource}}
```

<br />

 The resource bindings are always evaluated on the server. When evaluating, the current thread culture will be used. See the 
[Globalization](/docs/tutorials/basics-globalization/{branch}) section for more information about working with the request cultures.

