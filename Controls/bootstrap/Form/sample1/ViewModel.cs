using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Form.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public string[] Items => new[] { "one", "two", "three" };

        public string Item { get; set; } = "one";

        public bool Boolean1 { get; set; }

        public bool Boolean2 { get; set; }
    }
}