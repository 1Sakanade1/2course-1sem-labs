
interface IMovable
{
    void GetTripInfo();
}

class GoByPlane : IMovable
{
    public void GetTripInfo()
    {
        Console.WriteLine("Рейс самолётом");
    }
}

class GoByShip : IMovable
{
    public void GetTripInfo()
    {
        Console.WriteLine("Рейс по воде");
    }
}
class Trip
{
    protected int passengers; // кол-во пассажиров
    protected string type; // модель автомобиля

    public Trip(int num, string type, IMovable mov)
    {
        this.passengers = num;
        this.type = type;
        Movable = mov;
    }
    public IMovable Movable { private get; set; }
    public void GetTripInfo()
    {
        Movable.GetTripInfo();
    }
}