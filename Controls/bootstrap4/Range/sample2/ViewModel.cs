public class ViewModel : DotvvmViewModelBase
{
    
    public double Value { get; set; } = 1000;

    public int ValueChanges { get; set; }

    public bool Enabled { get; set; } = true;

    public void OnValueChanged() 
    {
        ValueChanges++;
    }

}
