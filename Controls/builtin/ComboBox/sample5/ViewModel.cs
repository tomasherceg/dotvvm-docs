using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Groups { get; set; } = { "Vegetables", "Fruits" };
        
        public string SelectedGroup { get; set; }


        public string[] Items { get; set; }
        
        public string SelectedItem { get; set; }
                


        public void GroupSelectionChanged()
        {
            if (SelectedGroup == "Fruits")
            {
                Items = new string[] { "Apple", "Banana", "Orange" };
            }
            else if (SelectedGroup == "Vegetables")
            {
                Items = new string[] { "Broccolini", "Lettuce", "Cabbage" };
            }
            else
            {
                Items = new string[] { };
            }
        }
    }
}