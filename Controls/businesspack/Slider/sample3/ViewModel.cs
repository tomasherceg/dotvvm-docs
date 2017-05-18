namespace DotvvmWeb.Views.Docs.Controls.businesspack.Slider.sample3
{
    public class ViewModel
    {
        public int Price { get; set; } = 50;
        public string PriceString { get; set; }

        public void PriceChanged()
        {
            PriceString = $"{Price}$";
        }
    }
}