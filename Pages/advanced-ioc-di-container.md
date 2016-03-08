## IoC/DI Containers

Dependency Injection is quite popular these days. In **DotVVM**, you can 
simply inject your dependencies and services into viewmodels.

You may have noticed the **ServiceLocator** property in the **DotvvmConfiguration** class.
This collection is used for resolving **DotVVM** internal services.

One of the services resolved through this mechanism is `IViewModelLoader` component.
This component is responsible for creating and initializing the instance of a viewmodel
for a particular view.

By default, **DotVVM** just reads the **@viewModel** directive and creates an instance 
of the class. We can simply create a mechanism which would replace the default behavior
and use the container to resolve the viewmodel.

### Creating a ViewModelLoader

First, you have to create your own ViewModelLoader. We recommend to inherit from
`DefaultViewModelLoader` and override the `CreateViewModelInstance` method.

```CSHARP
using System;
using Castle.Windsor;
using DotVVM.Framework.Runtime;

namespace DotvvmWeb.Installers
{
    public class WindsorViewModelLoader : DefaultViewModelLoader
    {
        private readonly WindsorContainer container;

        public WindsorViewModelLoader(WindsorContainer container)
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
any other container.
There is also a `DisposeViewModel` method which calls **Release** on the viewmodel.
This will tell the container that that class and its dependencies are no longer needed
and can be safely forgotten.


### Registering Custom ViewModel Loader

The last thing is to register the viewmode loader you have just created.
We should do this in the **Startup.cs** class:

```CSHARP
dotvvmConfiguration.ServiceLocator.RegisterSingleton<IViewModelLoader>(() => new WindsorViewModelLoader(container));
```
