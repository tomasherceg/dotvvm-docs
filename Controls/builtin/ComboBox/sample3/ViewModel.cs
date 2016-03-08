using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Fruit[] Fruits { get; set; } = 
        {
            new Fruit { Id = 0, Name = "Apple" },
            new Fruit { Id = 1, Name = "Banana" },
            new Fruit { Id = 2, Name = "Orange" }
        };

        public int SelectedFruitId { get; set; } = 1;

    }

    public class Fruit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }
}