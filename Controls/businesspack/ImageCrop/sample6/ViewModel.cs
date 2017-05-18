using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample6
{
    public class ViewModel
    {
        public string ImagePath { get; set; } = "/Resources/Images/picture.jpg";

        public ImageOperations ImageOperations { get; set; } = new ImageOperations {
            Crop = new CropRectangle {
                Left = 150,
                Top = 150,
                Width = 100,
                Height = 100
            },
            Resize = 400,
            Rotate = 45,
            Round = 50
        };
    }
}