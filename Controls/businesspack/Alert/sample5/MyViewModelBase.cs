using System;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample5
{
    public class MyViewModelBase : DotvvmViewModelBase
    {
        [Bind(Direction.ServerToClient)]
        public string AlertText { get; set; }

        [Bind(Direction.ServerToClient)]
        public AlertType AlertType { get; set; }

        /// <summary>
        /// Executes the specified action and sets the appropriate alert messages.
        /// </summary>
        protected void ExecuteWithAlert(Action actionToExecute, 
            string successText = "The operation was successful.", 
            string errorText = "Sorry, an unexpected error has occurred.")
        {
            try
            {
                actionToExecute();

                AlertText = successText;
                AlertType = AlertType.Success;
            }
            catch (Exception ex) when (!(ex is DotvvmInterruptRequestExecutionException))
            {
                AlertText = errorText;
                AlertType = AlertType.Danger;
            }
        }
    }
}