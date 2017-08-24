namespace DotvvmWeb.Views.Docs.Controls.businesspack.TabControl.sample2
{
    public class ViewModel
    {
        public int ChangeCount { get; set; }

        public string ActiveTabKey { get; set; } = "Other";

        public void TabChanged()
        {
            ChangeCount++;
        }
    }
}