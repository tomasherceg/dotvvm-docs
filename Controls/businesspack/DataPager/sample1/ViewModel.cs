using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DataPager.sample1
{
    public class ViewModel
    {
        public int PageSize { get; set; } = 5;
        public GridViewDataSet<Country> Countries { get; set; }

        public override Task Init()
        {
            Countries = new GridViewDataSet<Country> {
                OnLoadingData = GetData,
                PagingOptions = {
                    PageSize = PageSize
                },
            };
            Countries.SetSortExpression(nameof(Country.Id));

            return base.Init();
        }

        public GridViewDataSetLoadedData<Country> GetData(IGridViewDataSetLoadOptions gridViewDataSetOptions)
        {
            var queryable = GetQueryable(15);
            return queryable.GetDataFromQueryable(gridViewDataSetOptions);
        }

        private IQueryable<Country> GetQueryable(int size)
        {
            var numbers = new List<Country>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Country { Id = i + 1, Name = $"Country {i + 1}" });
            }
            return numbers.AsQueryable();
        }
    }
}