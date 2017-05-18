namespace DotvvmWeb.Views.Docs.Controls.businesspack.TabControl.sample2
{
    public class ViewModel
    {
        public int SelectedTabIndex { get; set; } = 1;
        public int ChangeCount { get; set; }

        public void TabChanged()
        {
            ChangeCount++;
        }
    }
}