using System.IO;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Storage;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        private readonly IUploadedFileStorage fileStorage;

        public ViewModel(IUploadedFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public UploadData Upload { get; set; } = new UploadData();

        public void Process()
        {
            var folterPath = GetUploadPath();

            // save all files to disk
            foreach (var file in Upload.Files)
            {
                var filePath = Path.Combine(folterPath, file.FileId + ".bin");
                fileStorage.SaveAs(file.FileId, filePath);
                fileStorage.DeleteFile(file.FileId);
            }

            // clear the data so the user can continue with other files
            Upload.Clear();
        }

        private string GetFolderdPath()
        {
            var folderPath = Path.Combine(Context.Configuration.ApplicationPhysicalPath, "MyFiles");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }
    }
}