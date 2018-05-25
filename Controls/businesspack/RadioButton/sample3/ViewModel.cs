using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Value { get; set; }

        public int NumberOfChanges { get; set; } = 0;

        public void OnChanged()
        {
            NumberOfChanges++;
        }
    }
}