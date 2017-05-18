namespace DotvvmWeb.Views.Docs.Controls.businesspack.Button.sample1
{
    public class ViewModel
    {
        public int ClicksCount { get; set; }

        public void Click()
        {
            ClicksCount++;
        }
    }
}