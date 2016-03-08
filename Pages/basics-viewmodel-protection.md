## ViewModel Protection

If you are curious why the _dotvvm.json_ file contains the security keys, here is the story.

Sometimes you want to persist some value between postbacks, however you don't want to show it to the client.
Of course you can put the value in the viewmodel and don't display it in the view, however clever users might
watch the communication between their browser and the server, so they'll be able to read the value.

For this scenarios, we have the `ViewModelProtection` attribute.

```CSHARP
[ViewModelProtection(ViewModelProtectionSettings.EncryptData)]
public string SecretValue { get; set; }
```

If you use the setting above, the value will not appear in the plain text in the viewmodel. It will be added to the
_$encryptedValues_ entry of the viewmodel and if you don't compromise the keys from the _dotvvm.json_ file, nobody should be able to read it.

Sometimes you need to display the value to the client, but you don't want the client to be able to change it.
Using javascript, everything in the viewmodel can be changed on the client side and then submitted to the server.

```CSHARP
[ViewModelProtection(ViewModelProtectionSettings.SignData)]
public string ClientReadOnlyValue { get; set; }
```

If you use the setting above, the value will be present in the viewmodel, but it will be also stored in the _$encryptedValues_ 
section. When the server deserializes the viewmodel, the encrypted value will be used instead of the plain text one. 
So the attackers are welcome to change this property value, however it will be ignored and the correct value from the encrypted part
will be used.

You also don't have to worry about storing things in the URL query string. The URL of the page is part of the encryption too,
so noone will be able to load a page /Admin/EditCustomer?id=1 and try to use encrypted values from another page.

> We strongly encourage you to put primary key of data displayed on the page (e.g. the ID of currently displayed order) 
to the URL to enforce security of the app.

> Also, don't you ever share the keys from dotvvm.json between apps. 

If you lose or compromise them, type `Generate-DotvvmSecurityKeys` into the Package Manager Console and generate a new pair.