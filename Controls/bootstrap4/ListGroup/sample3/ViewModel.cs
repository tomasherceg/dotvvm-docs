using DotVVM.Framework.Controls.Bootstrap4;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> LinksDataSet => new List<LinkItem>()
        {
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google", Badge = "1 References", Color = BootstrapColor.Info },
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools", Badge = "8 References", Color = BootstrapColor.Success },
            new LinkItem() { IsDisabled = false, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft", Badge = "3 References", Color = BootstrapColor.Warning },
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github", Badge = "15 References", Color = BootstrapColor.Danger }
        };
        
    }

    public class LinkItem
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDisabled { get; set; }
        public string Badge { get; set; }
        public BootstrapColor Color { get; set; }

    }
}