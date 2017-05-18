namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample3
{
    public class ViewModel
    {
        public bool Help { get; set; }
        public int ChangesCount { get; set; }

        public void Change()
        {
            ChangesCount++;
        }
    }
}