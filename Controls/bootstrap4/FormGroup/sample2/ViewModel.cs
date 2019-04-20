public class ViewModel : DotvvmViewModelBase
{
    public bool Red { get; set; } = false;
    public bool Blue { get; set; } = true;
    public string Text { get; set; }
    public void DoSomething()
    {
        if (Red && Blue)
        {
            Text = "You selected two colors";
        }
        else
        {
            Text = "You selected only one color";
        }
    }
}
