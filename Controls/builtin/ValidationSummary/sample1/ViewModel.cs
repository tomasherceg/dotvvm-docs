using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample1
{
    public class ViewModel
    {
        [Required]
        public string Text { get; set; }

        public void Send()
        {
            // process data
        }
    }
}