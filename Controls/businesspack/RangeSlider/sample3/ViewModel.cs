namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeSlider.sample3
{
    public class ViewModel
    {
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; } = 100;
        public string PriceRangeString { get; set; }

        public void PriceRangeChanged()
        {
            PriceRangeString = $"{MinimumPrice}$ - {MaximumPrice}$";
        }
    }
}