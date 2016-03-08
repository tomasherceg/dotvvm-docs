using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}