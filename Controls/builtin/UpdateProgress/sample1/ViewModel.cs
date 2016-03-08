using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.UpdateProgress.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Result { get; set; }

        public void CalculateIt()
        {
            // the calculation is very complicated and it takes a lot of time to get the result
            Thread.Sleep(5000);

            var random = new Random(DateTime.Now.Millisecond);
            Result = random.Next();
        }

    }
}