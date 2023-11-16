

interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver - Получатель
class Flight
{
    public void On()
    {
        Console.WriteLine("Рейс в активном состоянии!");
    }

    public void Off()
    {
        Console.WriteLine("Рейс отменен!");
    }
}

class FlightOnCommand : ICommand
{
    Flight Flight;
    public FlightOnCommand(Flight FlightSet)
    {
        Flight = FlightSet;
    }
    public void Execute()
    {
        Flight.On();
    }
    public void Undo()
    {
        Flight.Off();
    }
}

// Invoker - инициатор
class Commander
{
    ICommand command;

    public Commander() { }

    public void SetCommand(ICommand com)
    {
        command = com;
    }

    public void ActivateFlight()
    {
        command.Execute();
    }
    public void Undo()
    {
        command.Undo();
    }
}