namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample4
{
    public class ViewModel
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "IceCream", "Orange" };

        public string SelectedFruit { get; set; }

        public string Message { get; set; }

        public void IsItReallyFruit()
        {
            if (SelectedFruit == "IceCream")
            {
                Message = "Ice cream isn't a fruit!";
            }
            else
            {
                Message = "Yes, it's a fruit!";
            }
        }
    }
}