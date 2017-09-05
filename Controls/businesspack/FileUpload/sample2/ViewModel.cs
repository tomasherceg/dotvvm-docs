using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample2
{
    public class ViewModel
    {
        public string Message { get; set; }

        public UploadData Upload { get; set; } = new UploadData();

        public void ProcessFile()
        {
            // do what you have to do with the uploaded files
            Message = "ProcessFile() was called.";
        }
    }
}