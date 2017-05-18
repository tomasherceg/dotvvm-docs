using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample8
{
    public class ViewModel
    {
        public GridViewDataSet<Order> Orders { get; set; }
        public List<string> DeliveryTypes { get; set; } = new List<string> { "Post office", "Home" };

        public override Task Init()
        {
            Orders = new GridViewDataSet<Order> {
                OnLoadingData = GetData,
                RowEditOptions = new RowEditOptions {
                    PrimaryKeyPropertyName = nameof(Customer.Id),
                    EditRowId = -1
                }
            };
            Orders.SetSortExpression(nameof(Order.Id));

            return base.Init();
        }

        public GridViewDataSetLoadedData<Order> GetData(IGridViewDataSetLoadOptions gridViewDataSetOptions)
        {
            var queryable = GetQueryable(15);
            return queryable.GetDataFromQueryable(gridViewDataSetOptions);
        }

        private IQueryable<Order> GetQueryable(int size)
        {
            var numbers = new List<Order>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Order { Id = i + 1, DeliveryType = DeliveryTypes[(i + 1) % 2], IsPaid = (i + 1) % 2 == 0, CreatedDate = DateTime.Now.AddDays(-i) });
            }
            return numbers.AsQueryable();
        }
    }
}