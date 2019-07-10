Allows the user to upload one or multiple files asynchronously.


### Upload Configuration

The upload works on the background and starts immediately when the user selects the files. To make file uploading work, 
you have to specify where the temporary files will be uploaded.

The recommended strategy is to store the uploaded files in your application directory or in the temp directory (if your app have the appropriate permissions).
To define this, you have to register the `UploadedFileStorage` in the `IDotvvmServiceConfigurator`.

```CSHARP
public void ConfigureServices(IDotvvmServiceCollection options)
{
    options.AddUploadedFileStorage("App_Data/Temp");
}
```


### Using the Control

Then, you need to bind the `FileUpload` control to an `UploadedFilesCollection`. It is a collection which will hold references to the files 
the user has selected and uploaded.

This collection has a handy property `IsBusy` of `boolean` which indicated whether the file upload is still in progress. You can use it e.g. on
the button's `Enabled` property to disallow the user to continue until the upload is finished.


### Retrieving the Stored Files

The files are saved to a temporary location on the server. The `UploadedFilesCollection` holds only unique IDs of the files. To get the file contents, you have to retrieve them using the `IUploadedFileStorage` object. 

The simplest way to interact with `IUploadedFileStorage` service is to request it as a parameter in the viewmodel constructor.

```CSHARP
public class MyViewModel 
{

    private IUploadedFileStorage storage;

	public MyViewModel(IUploadedFileStorage storage)
	{
	    this.storage = storage;
	}
	
	...
}
```

You can then use the `GetFile` method to retrieve the `Stream` to access the file contents.

```CSHARP
foreach (var file in UploadedFiles.Files)
{
  if (file.IsAllowed)
  {
    // get the stream of the uploaded file and do whatever you need to do
    var stream = storage.GetFile(file.FileId);

    // OR you can just move the file from the temporary storage somewhere else
    var targetPath = Path.Combine(uploadPath, file.FileId + ".bin");
    storage.SaveAs(file.FileId, targetPath);
    
    // it is a good idea to delete the file from the temporary storage 
    // it is not required, the file would be deleted automatically after the timeout set in the DotvvmStartup.cs
    storage.DeleteFile(file.FileId);
  }
}
```

You should check the `FileTypeAllowed` and `MaxSizeExceeded` properties before you start to process the files. The file size and extension are validated on the client-side, but an attacker can easily pass these checks. 

You should delete the temporary files after they are processed. The files will be deleted automatically from the storage after 30 minutes. You can change this timeout or the specific storage implementation in `DotvvmStartup` - instead of calling `AddDefaultTempStorages`, just register any implementation of `IUploadedFileStorage` in the `IServiceCollection`.

&nbsp;