using System.Collections.Generic;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample1
{
    public class ViewModel
    {
        public UploadedFilesCollection Files { get; set; }


        public ViewModel()
        {
            Files = new UploadedFilesCollection();
        }
        
    }
}