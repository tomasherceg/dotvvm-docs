using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        private const int defaultPageSize = 5;

        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            PagingOptions = { PageSize = DefaultPageSize },
            SortingOptions =  {SortExpression = nameof(Customer.Id) }
        };

        public override Task Init()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }
            return base.Init();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}