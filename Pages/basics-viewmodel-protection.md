## ViewModel Protection

You often need to persist some value between postbacks, however you don't want to show it to the client. 
Of course you can put the value in the viewmodel and don't display it in the view, however clever users might
watch the communication between their browser and the server, so they'll be able to read the value.

Even bigger problems may occur when the user changes such value in the viewmodel, or intercepts the client-server communication
and modifies the request data. 

That's why we have the `Protect` attribute.

```CSHARP
[Protect(ProtectMode.EncryptData)]
public string SecretValue { get; set; }
```

If you use the setting above, the value will not appear in the viewmodel directly. Instead, it will be added to the
_$encryptedValues_ entry of the viewmodel and nobody will be able to read it.

Sometimes, you need to display the value to the client, but you don't want the client to be able to modify it.

```CSHARP
[Protect(ProtectMode.SignData)]
public string ClientReadOnlyValue { get; set; }
```

If you use the setting above, the value will be present in the viewmodel, but it will be also stored in the _$encryptedValues_ 
section. When the server deserializes the viewmodel, the encrypted value will be used instead of the plain text one. 
The attackers are welcome to change the property value in the viewmodel, however their change will be ignored and the correct
value from the encrypted field will be used.


### Things to Remember

The encryption and signing uses the `IDataProtectionProvider` from the `Owin.Security` package. In ASP.NET, it uses the standard machine key mechanism.
We use URL and current user identity to derive an encryption key. It means that also the URL and user identity is protected by default.
It is not possible for example to display a page `/admin/order/2` and send the HTTP POST request to another URL.

> We strongly encourage you to put primary key of data displayed on the page (e.g. the ID of currently displayed order) 
to the URL to enforce security of the app.