## IoC/DI Containers

Dependency Injection is quite popular these days. In **DotVVM**, you can 
simply inject your dependencies and services into viewmodels.

You may have noticed the `ServiceLocator` property in the `DotvvmConfiguration` class.
This collection is used for resolving **DotVVM-related** services.

One of the services resolved through this mechanism is `IViewModelLoader` component.
This component is responsible for creating and initializing the instance of a viewmodel
for a particular view.

By default, **DotVVM** just reads the `@viewModel` directive and creates an instance 
of the class. But we can simply create a mechanism which replace the default behavior
and use the container to resolve the viewmodel of the specified type.

### Creating a ViewModelLoader

First, you have to create your own `ViewModelLoader`. We recommend to inherit from
`DefaultViewModelLoader` and override the `CreateViewModelInstance` method because the 
`DefaultViewModelLoader` already resolves the type from the `@viewModel` directive.

```CSHARP
using System;
using Castle.Windsor;
using DotVVM.Framework.ViewModel.Serialization;

namespace Riganti.IS.Web.Installers
{
    public class WindsorViewModelLoader : DefaultViewModelLoader
    {
        private readonly WindsorContainer container;

        public WindsorViewModelLoader(WindsorContainer container, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.container = container;
        }

        protected override object CreateViewModelInstance(Type viewModelType)
        {
            return container.Resolve(viewModelType);
        }

        public override void DisposeViewModel(object instance)
        {
            container.Release(instance);
            base.DisposeViewModel(instance);
        }
    }
}
```

This sample uses **Castle Windsor** container, however it will be very similar with
any other DI container.

There is also a `DisposeViewModel` method which calls `Release` on the viewmodel.
This will tell the container that the instance and its dependencies are no longer needed
and can be safely released. This is because some containers track all instances they have created
which can cause memory leaks. 


### Registering Custom ViewModel Loader

The last thing is to replace the default viewmodel loader with the one you have just created.
We should do this in the `Startup.cs` class:

```CSHARP
dotvvmConfiguration.ServiceLocator.RegisterSingleton<IViewModelLoader>(() => new WindsorViewModelLoader(container));
```
