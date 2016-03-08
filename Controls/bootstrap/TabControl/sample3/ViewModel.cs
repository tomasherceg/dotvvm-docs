using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TabControl.sample3
{
    public class ViewModel
    {
        public List<TabData> Tabs { get; set; }

        public void Write(int index)
        {
            var selectedTab = Tabs.Single(t => t.Id == index);
            Text = selectedTab.Id + " - " + selectedTab.Name + " - " + selectedTab.Description;
        }

        public string Text { get; set; }

        public ViewModel()
        {
            Tabs = new List<TabData>()
                {
                    new TabData() { Id = 1, Name = "Tab 1", Description = "Tab one" },
                    new TabData() { Id = 2, Name = "Tab 2", Description = "Tab two" },
                    new TabData() { Id = 3, Name = "Tab 3", Description = "Tab three"},
                    new TabData() { Id = 4, Name = "Tab 4", Description = "Tab four" }
                };
        }
    }
    public class TabData
    {
        public bool IsActive { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}