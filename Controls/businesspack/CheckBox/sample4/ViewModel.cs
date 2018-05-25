using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<float> Extra { get; set; } = new List<float>();

        public float Price { get; set; } = 4;

        public void UpdatePrice()
        {
            Price = 4 + Extra.DefaultIfEmpty(0).Sum();
        }

    }
}