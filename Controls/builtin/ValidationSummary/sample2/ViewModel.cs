using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample2
{
    public class ViewModel
    {
        public ChildViewModel ChildObject { get; set; } = new ChildViewModel();

        public void Send()
        {
            // process data
        }
    }

    public class ChildViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}