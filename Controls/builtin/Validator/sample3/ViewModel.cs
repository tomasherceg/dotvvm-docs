using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationMessage.sample3
{
    public class ViewModel
    {

        [Required]
        public string Text { get; set; }

        [Required]
        public string Text2 { get; set; }


        public void Send()
        {
            // do the job
        }
    }
}