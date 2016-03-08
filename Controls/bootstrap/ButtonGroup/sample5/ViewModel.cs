using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<CheckBox> CheckBoxes { get; set; }

        public string SelectedColors { get; set; }
        public override Task PreRender()
        {
            CheckBoxes = new List<CheckBox>();
            CheckBoxes = GetData();
            return base.PreRender();
        }
        public ViewModel()
        {
            Colors = new List<string>();
            Colors.Add("red");
            Colors.Add("green");
        }
        public List<string> Colors { get; set; }

        public void UpdateSelectedColors()
        {
            SelectedColors = string.Join(", ", Colors.Select(i => i.ToString()));
        }

        private List<CheckBox> GetData()
        {
            return new List<CheckBox>
            {
                new CheckBox()
                {
                    Text="CheckBox 1",
                    CheckedValue = "reb"
                },
                new CheckBox()
                {
                    Text="CheckBox 2",
                    CheckedValue = "blue"
                },
                new CheckBox()
                {
                    Text="CheckBox 3",
                    CheckedValue = "green"
                }



            };
        }
    }

    public class CheckBox
    {
        public string Text { get; set; }
        public string CheckedValue { get; set; }



    }
}