using System.Collections.Generic;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample2
{
    public class ViewModel
    {
        public UploadedFilesCollection Files { get; set; }

        public string Message { get; set; }

        public ViewModel()
        {
            Files = new UploadedFilesCollection();
        }

        public void ProcessFile()
        {
            // do what you have to do with the uploaded files
            Message = "ProcessFile() was called.";
        }
    }
}