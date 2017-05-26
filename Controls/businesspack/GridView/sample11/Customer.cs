using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample11
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}