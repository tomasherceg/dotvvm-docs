using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample4
{
    public class ViewModel
    {
        public List<string> SelectedFileNames { get; set; } = new List<string>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };
    }
}