using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.CheckBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<double> Extra { get; set; } = new List<double>();

        public double Price { get; set; } = 4;

        public void UpdatePrice()
        {
            Price = 4 + Extra.DefaultIfEmpty(0).Sum();
        }

    }
}