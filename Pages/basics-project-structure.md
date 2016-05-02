## DotVVM Project Contents

After you [create a new DotVVM project](/docs/tutorials/how-to-start-dotnet-451/{branch}) you will find several things in your project.

* **Views\default.dothtml** - an example view.

* **ViewModels\DefaultViewModel.cs** - an example viewmodel.

* **Startup.cs** - an OWIN startup class which plugs in the DotVVM and Static Files middlewares.

* **DotvvmStartup.cs** - a DotVVM configuration file.

* **web.config** - a configuration file for ASP.NET and IIS.

<img src="{imageDir}basics-project-structure-img1.png" alt="DotVVM Project Structure" />

## Views and ViewModels Folders

Most people prefer to separate views and viewmodels in the **Views** and **ViewModels** folders. 
Also, there is a naming convention, that the file **default.dothtml** corresponds to the **DefaultViewModel** class.

If you install the [DotVVM for Visual Studio 2015](https://www.dotvvm.com/landing/dotvvm-for-visual-studio-extension), you can use the **F7** key to transition from 
your view to your viewmodel and **Shift-F7** back to your view.
