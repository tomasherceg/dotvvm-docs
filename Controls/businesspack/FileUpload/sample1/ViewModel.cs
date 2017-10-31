using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public UploadData Upload { get; set; } = new UploadData();
    }
}