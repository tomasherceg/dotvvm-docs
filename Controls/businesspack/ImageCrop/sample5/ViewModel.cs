using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample5
{
    public class ViewModel
    {
        public int ChangeCount { get; set; }
        public string ImagePath { get; set; } = "/Resources/Images/picture.jpg";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();

        public void Changed()
        {
            ChangeCount++;
        }
    }
}