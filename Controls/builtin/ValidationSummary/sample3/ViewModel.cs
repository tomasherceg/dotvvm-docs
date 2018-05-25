using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample3
{
    public class ViewModel
    {
        public ChildViewModel ChildObject { get; set; } = new ChildViewModel();

        public void Send()
        {
            // process data
        }
    }

    public class ChildViewModel : IValidatableObject
    {
        [Required]
        public string Text1 { get; set; }

        [Required]
        public string Text2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Text1 != Text2)
            {
                yield return new ValidationResult("This ChildViewModel is not valid.");
            }
        }
    }
}