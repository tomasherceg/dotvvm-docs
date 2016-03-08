using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Badge.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Clicks { get; set; } = 0;

        public void Increment()
        {
            Clicks++;
        }
    }
}