using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
        public WindowState State { get; set; } = WindowState.Maximized;
    }
}