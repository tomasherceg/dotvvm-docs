using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CurrentValue { get; set; } = 0;

        public async Task Calculate()
        {
            CurrentValue++;
        }

    }
}