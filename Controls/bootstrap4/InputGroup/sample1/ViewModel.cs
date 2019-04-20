public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; }
    public int Clicks { get; set; } = 0;
    

    public void UpdateText()
    {
        Clicks++;
        Text = "Button was clicked " + Clicks + 'x';
    }

    public bool Checked { get; set; }
    public string Text2 { get; set; } = "a";
    public string[] Values { get; set; } = new string[] { "a", "b", "c" };

    public void UpdateText2()
    {
        Text2 = "b";
    }
}