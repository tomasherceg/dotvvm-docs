using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.HtmlLiteral.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Html => "Hello <strong>DotVVM</strong>";
    }
}