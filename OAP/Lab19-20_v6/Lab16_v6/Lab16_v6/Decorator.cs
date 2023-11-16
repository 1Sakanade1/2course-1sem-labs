abstract class Travel
{
    public Travel(string n)
    {
        this.Name = n;
    }
    public string Name { get; protected set; }
    public abstract int GetCost();
}

class ShoppingTravel : Travel
{
    public ShoppingTravel() : base("Шоппинг тур")
    { }
    public override int GetCost()
    {
        return 10;
    }
}
class ExcursionTravel : Travel
{
    public ExcursionTravel()
        : base("Экскурсионный тур")
    { }
    public override int GetCost()
    {
        return 8;
    }
}

abstract class TravelDecorator : Travel
{
    protected Travel travel;
    public TravelDecorator(string n, Travel travel) : base(n)
    {
        this.travel = travel;
    }
}

class ExtraExcursionTravel : TravelDecorator
{
    public ExtraExcursionTravel(Travel p)
        : base(p.Name + ", с дополнительными экскурсиями", p)
    { }

    public override int GetCost()
    {
        return travel.GetCost() + 3;
    }
}

class GoodHotelTravel : TravelDecorator
{
    public GoodHotelTravel(Travel p)
        : base(p.Name + ", с хорошим номером в отеле", p)
    { }

    public override int GetCost()
    {
        return travel.GetCost() + 5;
    }
}