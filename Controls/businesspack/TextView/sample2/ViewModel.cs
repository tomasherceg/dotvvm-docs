using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextView.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ContactInfo { get; set; } = @"John Doe
                                                    Baker Street 82
                                                    john.doe@company.com
                                                    www.bakerbacon.com";
    }
}