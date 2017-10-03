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

Register classes by use extension method from package DotVVM.Framework.Integration.Electron to your IoC Container.
```
services.AddNeco();
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

  ### Usage
___




