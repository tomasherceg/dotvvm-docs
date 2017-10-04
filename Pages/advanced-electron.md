## Electron integration
[Electron](https://electron.atom.io/) is a cross platform framework for creating native application with web technologies like JavaScript, HTML and CSS. Electron uses Chromium and Node.js.

**DotVVM** has integration with Electron by WebSockets.
Integration with Electron is open source on github. You can check [here](https://github.com/riganti/dotvvm-electron).

### Getting Started
___


Required : **Node.js** 

You can use our [**dotnet new template**](https://github.com/riganti/dotvvm-electron/tree/master/_template) for creating a new project.
Or if  you want to setup manually, you must install this packages.
1. Install nuget package
```
Install-Package DotVVM.Framework.Integration.Electron
```

For use electron in your DotVVM project you need this extensions method.
```
services.AddElectronIntegration()
```
```
app.UseElectronIntegration();
```

2. In your package.json set dependency to **dotvvm-electron** module
```
  "dependencies": {
    "dotvvm-electron": "~0.0.15-beta1"
    ..
    ..
  }
  ```

  In your main.js/index.js, which you have defined in your **package.json** like main script, use dotvvm-electron module:
  ```
var dotvvmElectron = require('dotvvm-electron'); 
dotvvmElectron.run(__dirname);
  ```
In node.js is [__dirname](https://nodejs.org/docs/latest/api/modules.html#modules_dirname) global object.

  ### Sample
___

In your ViewModel you have created **ElectronService** (by DI/Manually), which is main class for comunication with electron.


**Sample** - Open MessageBox

In your ViewModel you have method something like ShowMessageBox, if you click on button you want call this method and open message box.

```
 public async Task ShowMessageBox()
    {
        var options = new ShowMessageBoxOptions
        {
            Title = "New MessageBox"
        };
        await _electronService.Dialog.ShowMessageBox(options);
    }
```
View.dotvvm
```
<dot:Button Text="Show MessageBox" Click="{command: ShowMessageBox()}" />
```


All availible modules and method you can find on our [Github repository](https://github.com/riganti/dotvvm-electron).


More samples you can find on our [Github repository](https://github.com/riganti/dotvvm-electron).
