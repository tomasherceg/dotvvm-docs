## Electron integration
[Electron](https://electron.atom.io/) is a cross platform framework for creating native application with web technologies like JavaScript, HTML and CSS. Electron uses Chromium and Node.js.

**DotVVM** has integration with Electron by WebSockets.
Integration with Electron is open source on github. You can check [here](https://github.com/riganti/dotvvm-electron).

### Getting Started

Required : **Node.js** 

You can use our **dotnet new template** for creating a new project. You can download template [here](https://github.com/riganti/dotvvm-electron/tree/master/_template).
Or if  you want setup manually, you must install this packages.
1. Install nuget package
```
Install-Package DotVVM.Framework.Integration.Electron
```
2. In your package.json set dependency to **dotvvm-electron** module
```
  "dependencies": {
    "dotvvm-electron": "~0.0.15-beta1"
    ..
    ..
  }
  ```
___

In your main.js/index.js, which you have defined in your package.json like main, use dotvvm-electron module like:
  ```
var dotvvmElectron = require('dotvvm-electron'); 
dotvvmElectron.run(__dirname);
  ```
In node.js is [__dirname](https://nodejs.org/docs/latest/api/modules.html#modules_dirname) global object.
