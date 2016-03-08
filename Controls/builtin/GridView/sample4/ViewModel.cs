using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Customer[] Customers { get; set; } = {
            new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"),new Customer(2,"Raine Damian"),
            new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
        };

        public string SelectedSortColumn { get; set; }

        public void Sort(string column)
        {
            SelectedSortColumn = column;
        }

        public override Task PreRender()
        {
            switch (SelectedSortColumn)
            {
                case "Name":
                    Customers = Customers.OrderBy(c => c.Name).ToArray();
                    break;
                case "Id":
                    Customers = Customers.OrderBy(c => c.Id).ToArray();
                    break;
            }
            return base.PreRender();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            // NOTE: This default constructor is required. 
            // Remember that the viewmodel is JSON-serialized
            // which requires all objects to have a public 
            // parameterless constructor
        }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}