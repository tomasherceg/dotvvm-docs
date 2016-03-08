using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2
{
    public class PageViewModel : BaseViewModel
    {
        public int CurrentValue { get; set; } = 0;

        public void Calculate()
        {
            CurrentValue++;
        }
    }
}
