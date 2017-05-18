using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample13
{
    public class ViewModel
    {
        public Customer PrintedCustomer { get; set; }
        public GridViewDataSet<Customer> Customers { get; set; }

        public override Task Init()
        {
            Customers = new GridViewDataSet<Customer> {
                OnLoadingData = GetData
            };
            Customers.SetSortExpression(nameof(PrintedCustomer.Id));

            return base.Init();
        }

        [AllowStaticCommand]
        public void PrintCustomer(Customer customer)
        {
            PrintedCustomer = customer;
        }

        public GridViewDataSetLoadedData<Customer> GetData(IGridViewDataSetLoadOptions gridViewDataSetOptions)
        {
            var queryable = GetQueryable(15);
            return queryable.GetDataFromQueryable(gridViewDataSetOptions);
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return numbers.AsQueryable();
        }
    }
}