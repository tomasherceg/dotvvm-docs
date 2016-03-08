using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.InlineScript.sample2
{
    public class ViewModel
    {
        public void NeverEverRunThis()
        {
            throw new Exception("This method was called from View Model.");
        }

    }
}