using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.NumericUpDown.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; }
        public int ChangeCount { get; set; }

        public void ValueChanged()
        {
            ChangeCount++;
        }
    }
}