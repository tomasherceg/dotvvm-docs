namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample5
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