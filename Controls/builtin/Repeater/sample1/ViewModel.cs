using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Items { get; set; } = { "First", "Second", "Third" };

    }
}