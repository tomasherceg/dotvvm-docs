using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample10
{
    public class ViewModel : DotvvmViewModelBase
    {
        public GridViewUserSettings UserSettings { get; set; }
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = {SortExpression = nameof(Customer.Id)}
        };

        public override Task Init()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            UserSettings = new GridViewUserSettings {
                EnableUserSettings = true,
                ColumnsSettings = new List<GridViewColumnSetting> {
                    new GridViewColumnSetting {
                        ColumnName = "CustomerId",
                        DisplayOrder = 0,
                        ColumnWidth = 50
                    },
                    new GridViewColumnSetting {
                        ColumnName = "CustomerName",
                        DisplayOrder = 1,
                        ColumnWidth = 400
                    },
                    new GridViewColumnSetting {
                        ColumnName = "CustomerBirthdate",
                        DisplayOrder = 2
                    },
                    new GridViewColumnSetting {
                        ColumnName = "CustomerOrders",
                        DisplayOrder = 3
                    }
                }
            };

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