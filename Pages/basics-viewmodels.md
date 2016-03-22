## ViewModels

In **DotVVM**, the **viewmodel** can be any JSON-serializable class. The viewmodel represents the state of the page and contains commands which
can be invoked from the UI. Theoretically, if you serialize the viewmodel and later you deserialize it and apply to the DOTHTML view, the page should be
in exactly same state. 

The viewmodel contains the _properties_ used in the bindings and _methods_ that can be called from the page (e.g. by clicking a button).

### Recommendations for ViewModels

+ The viewmodel is a C# class that derives from `DotvvmViewModelBase`. 

+ Viewmodel contains properties of a primitive types (string, int, double...), collections (List&lt;T&gt; or array) or 
other objects that comply with this paragraph. Everything must be JSON-serializable.

+ The properties in viewmodel and all objects it contains, should have plain `{ get; set; }`. There should be no logic in getters, setters 
or the constructor of the class.

+ It contains several methods that can be called from the UI. These methods shouldn't do anything complicated. If there is 
some complex stuff that needs to be done, the method wil use some other class to do the job. 
In general, the viewmodel methods should only gather data from the viewmodel, call a method that does the real job and after it's finished, 
update the viewmodel properties with results of the called method. 

Please don't put code that retrieves the data or updates records in the database, sends e-mails or does anything complicated 
directly in the viewmodel. You'll end with one big mess which will be difficult to maintain.
See the [samples](/docs/samples) to see how to architect the application in the layers.

> Don't use Entity Framework entities directly in your viewmodel. They'll cause issues during the serialization because JSON serializer doesn't support
cyclic references, and the lazy loading on entity properties can cause transferring much more data than necessary. <br> 
If you are using Entity Framework, create [Data Transfer Objects](https://en.wikipedia.org/wiki/Data_transfer_object) and use them in your viewmodel instead. 


### DotvvmViewModelBase

If the viewmodel derives from the `DotvvmViewModelBase`, it can override the `Init`, `Load` and `PreRender` methods. The lifecycle 
of the request looks like this. On the left side, you can see what's going on when the client access the page first time 
(the GET request). On the right side you can see what happens during the postback (when the user clicks a button).

<p><img src="{imageDir}basics-viewmodels-img1.png" alt="Dotvvm Page Lifecycle" /></p>

## Binding Directions

When using the [command bindings](/docs/tutorials/basics-command-binding/{branch}), you may need to customize which properties are transferred 
from the server to client or from client to the server. Typically, there is no need to transfer the whole viewmodel in both directions. 

In DotVVM, you can configure what data is transferred using the `[Bind(direction)]` attribute. 

The direction is an enumeration with the following options - `Both`, `ServerToClient`, `ClientToServer` and `None`.

* **Both** is the default value - the property is transferred in both ways.

* **ServerToClient** - the changes of the property on the client side are not transferred to the server.

* **ClientToServer** - the server only reads the value of the property set by the client.

* **None** - the property is not serialized in any way.
