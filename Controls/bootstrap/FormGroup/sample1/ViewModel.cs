using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.FormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public string[] Items => new[] { "one", "two", "three" };

        public string Item { get; set; } = "one";

        public bool IsChecked { get; set; }

        public bool Radio { get; set; }
    }
}