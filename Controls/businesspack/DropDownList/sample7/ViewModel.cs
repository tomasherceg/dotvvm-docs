using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DropDownList.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}