using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public BusinessPackDataSet<Order> Orders { get; set; } = new BusinessPackDataSet<Order>()
        {
            SortingOptions = { SortExpression = nameof(Order.Id) }, 
            RowEditOptions = { PrimaryKeyPropertyName = nameof(Order.Id), EditRowId = -1 }
        };

        public List<string> DeliveryTypes { get; set; } = new List<string> { "Post office", "Home" };

        public override Task Init()
        {
            if(Orders.IsRefreshRequired)
            {
                Orders.LoadFromQueryable(GetQueryable(15));
            }

            return base.Init();
        }

        public GridViewDataSetLoadedData<Order> GetData(IGridViewDataSetLoadOptions gridViewDataSetOptions)
        {
            var queryable = GetQueryable(15);
            return queryable.GetDataFromQueryable(gridViewDataSetOptions);
        }

        private IQueryable<Order> GetQueryable(int size)
        {
            var orders = new List<Order>();
            for (var i = 0; i < size; i++)
            {
                orders.Add(new Order { Id = i + 1, DeliveryType = DeliveryTypes[(i + 1) % 2], IsPaid = (i + 1) % 2 == 0, CreatedDate = DateTime.Now.AddDays(-i) });
            }
            return orders.AsQueryable();
        }
    }
}