using DotVVM.Framework.ViewModel;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ModalDialog.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsModalDisplayed { get; set; }

        public VerticalAlignment CurrentVerticalAlignment { get; set; } = VerticalAlignment.Bottom;
        public HorizontalAlignment CurrentHorizontalAlignment { get; set; } = HorizontalAlignment.Right;
    }
}