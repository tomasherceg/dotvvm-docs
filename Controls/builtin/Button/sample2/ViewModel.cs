using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {

        public bool Enabled { get; set; } = true;

        public bool Visible { get; set; } = false;

        public void SetEnabled()
        {
            Enabled = true;
            Visible = false;
        }

        public void SetVisible()
        {
            Visible = true;
            Enabled = false;
        }

    }

}