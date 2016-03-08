using System.IO;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Storage;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public UploadedFilesCollection Files { get; set; }


        public ViewModel()
        {
            Files = new UploadedFilesCollection();
        }


        public void Process()
        {
            var storage = Context.Configuration.ServiceLocator.GetService<IUploadedFileStorage>();

            var uploadPath = GetUploadPath();

            // save all files to disk
            foreach (var file in Files.Files)
            {
                var targetPath = Path.Combine(uploadPath, file.FileId + ".bin");
                storage.SaveAs(file.FileId, targetPath);
                storage.DeleteFile(file.FileId);
            }

            // clear the uploaded files collection so the user can continue with other files
            Files.Clear();
        }

        private string GetUploadPath()
        {
            var uploadPath = Path.Combine(Context.Configuration.ApplicationPhysicalPath, "MyFiles");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            return uploadPath;
        }
    }
}