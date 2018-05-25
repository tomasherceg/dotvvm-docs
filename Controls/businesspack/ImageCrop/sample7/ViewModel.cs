using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "/Resources/Images/picture.jpg";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}