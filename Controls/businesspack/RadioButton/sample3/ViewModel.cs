namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample3
{
    public class ViewModel
    {
        public bool Value { get; set; }

        public int NumberOfChanges { get; set; } = 0;

        public void OnChanged()
        {
            NumberOfChanges++;
        }
    }
}