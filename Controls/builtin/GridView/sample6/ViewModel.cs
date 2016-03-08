using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.Sample6
{
    public class ViewModel : DotvvmViewModelBase
    {

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>()
        {
            PrimaryKeyPropertyName = "Id"
        };

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                // fill the dataset for the first time
                Refresh();
            }
            return base.PreRender();
        }

        private void Refresh()
        {
            // TODO: load data from the database
            Customers.Items = new List<Customer>()
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"), new Customer(2, "Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
            };
            Customers.TotalItemsCount = Customers.Items.Count;
        }

        public void Edit(Customer customer)
        {
            Customers.EditRowId = customer.Id;
        }

        public void Update(Customer customer)
        {
            // TODO: save changes to the database
            Customers.EditRowId = null;

            // uncomment this line - it's here only for the sample to work without database
            //Refresh();
        }

        public void CancelEdit()
        {
            Customers.EditRowId = null;

            // uncomment this line - it's here only for the sample to work without database
            //Refresh();
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