using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.LinkButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Enabled { get; set; } = true;

        public void Switch()
        {
            Enabled = !Enabled;
        }

        public void DoSomething()
        {
            
        }

    }
}