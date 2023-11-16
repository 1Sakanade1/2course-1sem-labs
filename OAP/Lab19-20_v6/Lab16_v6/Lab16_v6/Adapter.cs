interface IVouchTransport
{
    void Fly();
}
// класс машины
class Plane : IVouchTransport
{
    public void Fly()
    {
        Console.WriteLine("Прибытие в пункт назначения самолётом");
    }
}
class Flyer
{
    public void Travel(IVouchTransport transport)
    {
        transport.Fly();
    }
}
// интерфейс животного
interface IShip
{
    void Move();
}
// класс верблюда
class Ship : IShip
{
    public void Move()
    {
        Console.WriteLine("Прибытие в пункт назначения по воде");
    }
}
// Адаптер от Ship к IVouchTransport
class ShipToTransportAdapter : IVouchTransport
{
    Ship ship;
    public ShipToTransportAdapter(Ship c)
    {
        ship = c;
    }

    public void Fly()
    {
        ship.Move();
    }
}