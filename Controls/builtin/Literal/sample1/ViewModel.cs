using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Literal.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text => "Hello DotVVM";

        public DateTime Date => DateTime.Now;
    }
}