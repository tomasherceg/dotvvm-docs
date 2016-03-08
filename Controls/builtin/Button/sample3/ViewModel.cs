using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SubmittedValue { get; set; } = 0;
        public int CurrentValue { get; set; } = 0;

        public string Message { get; set; } = "";

        public void Calculate()
        {
            CurrentValue++;
            Message = "";
        }

        public void ShowMessage()
        {
            Message = "Value submitted.";
            SubmittedValue = CurrentValue;
        }

    }
}