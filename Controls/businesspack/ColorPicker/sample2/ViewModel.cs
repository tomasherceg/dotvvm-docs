using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample2
{
    public class ViewModel
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);

        public List<string> MyColors { get; set; } = new List<string> {
            "#FFFFFF", "#000", "C00000", "#E6E6E6", "44546A", "447260",
            "ED7D31", "FFC000", "5B9BD5", "70AD47", "#FF0000"
        };
    }
}