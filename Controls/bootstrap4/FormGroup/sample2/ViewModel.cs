using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.FormGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Red { get; set; } = false;
        public bool Blue { get; set; } = true;
        public string Text { get; set; }
        public void DoSomething()
        {
            if(Red && Blue)
            {
                Text = "You select two colors";
            }
            else
            {
                Text = "You select only one color";
            }
        }
    }
}