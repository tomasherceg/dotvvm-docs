using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ModalDialog.sample2
{
    public class ViewModel
    {
        public string Title { get; set; } = "Title of modal window";
        public string Header { get; set; } = "Header of modal window.";
        public string Body { get; set; } = "This is body content.";
        public string Footer { get; set; } = "Footer of modal window.";
        public bool Displayed { get; set; } = false;
    }
}