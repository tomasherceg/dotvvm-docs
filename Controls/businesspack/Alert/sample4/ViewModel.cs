namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample4
{
    public class ViewModel : MyViewModelBase
    {        
        public void DoSomething()
        {
            ExecuteWithAlert(() =>
            {
                // the action
            });
        }
    }
    
}