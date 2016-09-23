using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedItem { get; set; }
        public Item[] Items { get; set; } =
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" },
            new Item { Id = 3, Name = "Item 3" },
        };
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
