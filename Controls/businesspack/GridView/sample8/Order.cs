using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample8
{
    public class Order
    {
        public int Id { get; set; }
        public string DeliveryType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}