using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.TextBoxFormGroup.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string UpdateTestText { get; set; } = "Change this";
        public string ChangedValue { get; set; } = "Not changed";
        public string ChangedTestText { get; set; } = "text";

        public void Changed()
        {
            ChangedValue = "Changed to " + ChangedTestText;
        }
    }
}