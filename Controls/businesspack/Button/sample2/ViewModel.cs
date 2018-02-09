using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Button.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEnabled { get; set; }
        public bool IsVisible { get; set; } = true;

        public void ShowButton()
        {
            IsEnabled = false;
            IsVisible = true;
        }

        public void HideButton()
        {
            IsVisible = false;
            IsEnabled = true;
        }
    }
}