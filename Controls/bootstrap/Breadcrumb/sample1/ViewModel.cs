using DotVVM.Framework.ViewModel;
using System;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {

        public string Test { get; set; } = "15";

        public string Id { get; set; }

        public override Task Init()
        {
            if (Context.Parameters.ContainsKey("Id"))
            {
                Id = Convert.ToString(Context.Parameters["Id"]);
            }
            return base.Init();
        }
    }
}