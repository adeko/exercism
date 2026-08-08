class RemoteControlCar
{
    int _batteryDrain = 0;
    int _speed = 0;
    
    int _batteryCharge = 100;
    int _distanceDriven = 0;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _batteryCharge <= 0 || _batteryDrain > _batteryCharge;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if (!this.BatteryDrained())
        {
            _batteryCharge -= _batteryDrain;
            _distanceDriven += _speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    int _distance = 0;
    
    public RaceTrack(int distance)
    {
        _distance = distance;        
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < _distance)
        {
            car.Drive();            
        }
        return car.DistanceDriven() >= _distance;
    }
}
