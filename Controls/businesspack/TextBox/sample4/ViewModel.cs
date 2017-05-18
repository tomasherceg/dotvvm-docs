namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample4
{
    public class ViewModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }

        public int Text1ChangeCount { get; set; }
        public int Text2ChangeCount { get; set; }

        public void Text1Changed() => Text1ChangeCount++;
        public void Text2Changed() => Text2ChangeCount++;
    }
}