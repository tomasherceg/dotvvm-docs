namespace DotvvmWeb.Views.Docs.Controls.businesspack.Rating.sample3
{
    public class ViewModel
    {
        public double Rating { get; set; } = 4.5;
        public int ChangeCount { get; set; }

        public void RatingChanged()
        {
            ChangeCount++;
        }
    }
}