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
            new PanelData("Text 1"),
            new PanelData("Text 2"),
            new PanelData("Text 3")
        };
    }

    public class PanelData
    {
        public string Text { get; set; }

        public PanelData()
        {
        }

        public PanelData(string text)
        {
            Text = text;
        }
    }
}