using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.Sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<Customer> FakeDb()
        {
            return new[]
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"),new Customer(2,"Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
            }.AsQueryable();
        }

        private GridViewDataSetLoadedData<Customer> GetData(IGridViewDataSetLoadOptions gridViewDataSetLoadOptions)
        {
            var queryable = FakeDb();
            // NOTE: Apply Pagign and Sorting options.
            return queryable.GetDataFromQueryable(gridViewDataSetLoadOptions);
        }

        public GridViewDataSet<Customer> Customers { get; set; }

        public override Task Init()
        {
            Customers = new GridViewDataSet<Customer>()
            {
                OnLoadingData = GetData,
                RowEditOptions = new RowEditOptions() { PrimaryKeyPropertyName = "Id" }
            };
            return base.Init();
        }

        public void Edit(Customer customer)
        {
            Customers.RowEditOptions.EditRowId = customer.Id;
        }

        public void Update(Customer customer)
        {
            // TODO: save changes to the database
            Customers.RowEditOptions.EditRowId = null;

            // uncomment this line - it's here only for the sample to work without database
            //Customers.RequestRefresh(forceRefresh: true);
        }

        public void CancelEdit()
        {
            Customers.RowEditOptions.EditRowId = null;

            // uncomment this line - it's here only for the sample to work without database
            //Customers.RequestRefresh(forceRefresh: true);
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