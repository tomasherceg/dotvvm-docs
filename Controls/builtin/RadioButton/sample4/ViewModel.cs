using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public float PriceWithoutTax { get; set; }

        public float Tax { get; set; }

        public float Price { get; set; }

        public void UpdatePrice()
        {
            Price = PriceWithoutTax + ((PriceWithoutTax / 100) * Tax);
        }

    }
}