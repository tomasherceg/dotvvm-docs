namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample3
{
    public class ViewModel
    {
        public Fruit[] Fruits { get; set; } = 
        {
            new Fruit(0, "Apple"),
            new Fruit(1, "Banana"),
            new Fruit(2, "Orange")
        };

        public int SelectedFruitId { get; set; } = 1;
    }

    public class Fruit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Fruit(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}