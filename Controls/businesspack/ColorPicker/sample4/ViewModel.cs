using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample4
{
    public class ViewModel
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
        public string CssColor { get; set; }

        public void ColorChanged()
        {
            CssColor = Color.ToCssColor();
        }
    }
}