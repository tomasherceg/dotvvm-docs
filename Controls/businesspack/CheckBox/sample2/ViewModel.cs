using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample2
{
    public class ViewModel
    {
        public List<double> Extras { get; set; } = new List<double>();
        public double Price { get; set; }

        public void UpdatePrice()
        {
            Price = Extras.DefaultIfEmpty(0).Sum();
        }
    }
}