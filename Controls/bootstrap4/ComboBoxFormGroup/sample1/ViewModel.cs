using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.ComboBoxFormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}