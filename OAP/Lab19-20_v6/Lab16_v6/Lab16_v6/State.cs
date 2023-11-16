enum FlightState
{
    PREPARATION,
    TAKE_OFF,
    LANDING
}
class FlightS
{
    public FlightState State { get; set; }

    public FlightS(FlightState fs)
    {
        State = fs;
    }

    public void StandingPlane()
    {
        if (State == FlightState.PREPARATION)
        {
            Console.WriteLine("Подготовка к взлёту");
            State = FlightState.TAKE_OFF;
        }
        else if (State == FlightState.TAKE_OFF)
        {
            Console.WriteLine("Взлёт");
            State = FlightState.LANDING;
        }
        else if (State == FlightState.LANDING)
        {
            Console.WriteLine("Самолет не в полёте");
            State = FlightState.TAKE_OFF;
        }
    }
    public void FlyingPlane()
    {
        if (State == FlightState.PREPARATION)
        {
            Console.WriteLine("Самолёт уже летит!");
            State = FlightState.TAKE_OFF;
        }
        else if (State == FlightState.TAKE_OFF)
        {
            Console.WriteLine("Самолёт уже летит!");
            State = FlightState.TAKE_OFF;
        }
        else if (State == FlightState.LANDING)
        {
            Console.WriteLine("Посадка");
            State = FlightState.PREPARATION;
        }
    }
}