class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    
    public int Precision { get; private set; }

    public double Weight 
    { 
        get; 
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            field = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    public string DisplayWeight 
    { 
        get 
        {
            return (Weight - TareAdjustment).ToString("F" + Precision) + " kg";
        }
    }
}
