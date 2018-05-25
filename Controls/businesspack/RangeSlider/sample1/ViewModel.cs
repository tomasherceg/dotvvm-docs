using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeSlider.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; } = 100;
    }
}