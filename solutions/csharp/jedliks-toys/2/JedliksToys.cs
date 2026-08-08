class RemoteControlCar
{
    public static RemoteControlCar Buy() => new RemoteControlCar();

    int Distance { get; set; } = 0;
    int Battery { get; set; } = 100;

    public RemoteControlCar()
    {
    }

    public string DistanceDisplay()
    {
        return $"Driven {Distance} meters";
    }

    public string BatteryDisplay()
    {
        if (Battery <= 0) return "Battery empty";
        return $"Battery at {Battery}%";
    }

    public void Drive()
    {
        if (Battery <= 0) return;
        Distance += 20;
        Battery -= 1;
    }
}
