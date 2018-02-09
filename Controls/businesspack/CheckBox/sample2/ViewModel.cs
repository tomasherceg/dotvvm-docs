using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<double> Extras { get; set; } = new List<double>();
        public double Price { get; set; }

        public void UpdatePrice()
        {
            Price = Extras.DefaultIfEmpty(0).Sum();
        }
    }
}