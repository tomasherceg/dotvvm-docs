## Bundling and Minification

You can register an object implementing the `IResourceProcessor` interface in the resource repository. This object can perform additional actions with the collection of resources that is being rendered. 

### Bundling

It can be used e.g. for bundling. You can bundle several resources in one file and configure DotVVM to include the bundle in the page instead of including the individual resources. You can use the `BundlingResourceProcessor` class for this. 

Please note that this class doesn't do the bundling automatically. You need to combine the script files or stylesheets yourself and register it as a new resource.
Then you can use this class which replaces the resources which are part of the bundle with the bundle itself. 

```CSHARP
var bundling = new BundlingResourceProcessor();
bundles.RegisterBundle(dotvvmConfiguration.Resources.FindNamedResource("myBundle"), "script1", "script2");
dotvvmConfiguration.Resources.DefaultResourceProcessors.Add(bundling);
```

### Minification

Currently, DotVVM doesn't help with minification of resources. However, you can write your own `IResourceProcessor` that will replace debug resources with the minifiedones when running in the production environment.