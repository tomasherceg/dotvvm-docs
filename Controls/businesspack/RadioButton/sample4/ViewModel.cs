using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample4
{
	public class ViewModel : DotVVM.BusinessPack.DocSamples.Samples.LayoutViewModel
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