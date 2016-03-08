## DotVVM Project Contents

You can find several item in the default **DotVVM** project template.

* **Views\default.dothtml** - an example view file.

* **ViewModels\DefaultViewModel.cs** - an example viewmodel file.

* **dotvvm.json** - a DotVVM configuration file which contains security keys, control tag mappings and other configuration stuff.

* **Startup.cs** - a file which contains startup code for DotVVM, route registrations and other initialization tasks.

* **web.config** - good old ASP.NET configuration file.


_The dotvvm.json file contains security keys that are used to protect viewmodels on the client side. 
Please do not copy security keys from one project to another. If you lose or compromise them, 
run `Generate-DotVVMSecurityKeys` in the Package Manager Console to generate a new pair._



## Views and ViewModels Folders

Some people prefer to separate views and viewmodels in the **Views** and **ViewModels** folders. 
Also, there is a naming convention, that the file **default.dothtml** corresponds to the **DefaultViewModel** class.

However, if you don't like these conventions, feel free to create your own!