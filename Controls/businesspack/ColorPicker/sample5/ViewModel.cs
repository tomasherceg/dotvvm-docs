using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
    }
}
