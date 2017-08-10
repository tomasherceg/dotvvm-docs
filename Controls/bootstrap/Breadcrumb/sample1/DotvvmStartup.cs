using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Bootstrap;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample1
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrapConfiguration();

            config.RouteTable.Add("MyRoute", "myRoute/{Id}", "Views/page.dothtml");
        }
    }
}