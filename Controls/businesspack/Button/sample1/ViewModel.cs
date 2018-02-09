using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Button.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int ClicksCount { get; set; }

        public void Click()
        {
            ClicksCount++;
        }
    }
}