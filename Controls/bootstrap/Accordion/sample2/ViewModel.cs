using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Accordion.sample2
{
    public class ViewModel
    {
        public int Index { get; set; } = 1;

        public PanelData[] Panels { get; set; } =
        {
            new PanelData("Footer 1", "Header 1", "Text 1"),
            new PanelData("Footer 2", "Header 2", "Text 2"),
            new PanelData("Footer 3", "Header 3", "Text 3")
        };
    }

    public class PanelData
    {
        public string Text { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public PanelData()
        {
        }

        public PanelData(string footer, string header, string text)
        {
            Footer = footer;
            Header = header;
            Text = text;
        }
    }
}