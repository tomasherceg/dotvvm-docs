using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CurrentValue { get; set; } = 0;

        public void Calculate()
        {
            CurrentValue++;
        }

    }
}