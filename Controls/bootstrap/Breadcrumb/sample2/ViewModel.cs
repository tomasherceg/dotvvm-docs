using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> Links { get; set; }

        private static IQueryable<LinkItem> GetData()
        {
            return new[]
            {
                new LinkItem()
                {
                    IsDisabled = true,
                    IsSelected = false,
                    NavigateUrl = "https://www.google.com/",
                    Text = "Google"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = false,
                    NavigateUrl = "http://www.w3schools.com/html/",
                    Text = "W3Schools"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = true,
                    NavigateUrl = "https://www.microsoft.com/en-us/",
                    Text = "Microsoft"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = false,
                    NavigateUrl = "https://github.com/riganti/dotvvm",
                    Text = "DotVVM Github"
                }
            }.AsQueryable();
        }

        public ViewModel()
        {
            Links = new List<LinkItem>(GetData());
        }

    }

    public class LinkItem
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDisabled { get; set; }

    }
}


