using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DropDownButton.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> LinksDataSet { get; set; }

        private static IQueryable<LinkItem> GetData()
        {
            return new[]
            {
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google"},
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools"},
                new LinkItem() {  IsDisabled = false, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft"},
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github"}
            }.AsQueryable();
        }

        public ViewModel()
        {
            LinksDataSet = new List<LinkItem>();
            foreach (LinkItem l in GetData())
            {
                LinksDataSet.Add(l);
            }
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