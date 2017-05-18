using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample4
{
    public class ViewModel
    {
        public string ImagePath { get; set; } = "/Resources/Images/picture.jpg";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}