using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample7
{
    public class ViewModel
    {
        public bool IsInserting { get; set; }
        public BpGridViewDataSet<Customer> Customers { get; set; }

        public override Task Init()
        {
            Customers = new BpGridViewDataSet<Customer> {
                OnLoadingData = GetData,
                RowEditOptions = new RowEditOptions {
                    PrimaryKeyPropertyName = nameof(Customer.Id)
                }
            };
            Customers.SetSortExpression(nameof(Customer.Id));

            return base.Init();
        }

        public void InsertNewCustomer()
        {
            Customers.RowInsertOptions.InsertedItem = new Customer {
                Id = Customers.Items.Max(c => c.Id) + 1,
                Orders = 0
            };
            IsInserting = true;
        }

        public void CancelInsertNewCustomer()
        {
            Customers.RowInsertOptions.InsertedItem = null;
            IsInserting = false;
        }

        public void SaveNewCustomer()
        {
            // Save inserted item to database
            Customers.Items.Add(Customers.RowInsertOptions.InsertedItem);
            CancelInsertNewCustomer();
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