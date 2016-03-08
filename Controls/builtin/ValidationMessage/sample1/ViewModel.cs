using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationMessage.sample1
{
    public class ViewModel
    {
        
        [Required]
        public string Text { get; set; }

        public void Send()
        {
            // do the job
        }
    }
}