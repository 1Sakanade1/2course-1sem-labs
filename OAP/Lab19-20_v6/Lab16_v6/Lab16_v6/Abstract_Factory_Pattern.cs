
namespace af {
    

abstract public class Excursion
{
    public abstract void GetExcursionRoute();
}

abstract public class TransportType
{
    public abstract void ShowRoute();
}


public class SightExcursion : Excursion
{
    public override void GetExcursionRoute()
    {
        Console.WriteLine("Экскурсия по достопримечательностям");
    }
}

public class MonumentExcursion : Excursion
{
    public override void GetExcursionRoute()
    {
        Console.WriteLine("Экскурсия по памятникам");
    }
}

public class Airline : TransportType
    {
    public override void ShowRoute()
    {
        Console.WriteLine("Маршрут - полёт");
    }
}

public class MarineCompany : TransportType
{
    public override void ShowRoute()
    {
        Console.WriteLine("Маршрут - морем");
    }
}

abstract public class VoucherFactory
{
    public abstract TransportType CreateTransportType();
    public abstract Excursion CreateExcursion();
}

public class AirlineVoucher : VoucherFactory
{
    public override TransportType CreateTransportType()
    {
        return new Airline();
    }

    public override Excursion CreateExcursion()
    {
        return new SightExcursion();
    }
}
public class MarineVoucher : VoucherFactory
{
    public override TransportType CreateTransportType()
    {
        return new MarineCompany();
    }

    public override Excursion CreateExcursion()
    {
        return new MonumentExcursion();
    }
}
public class Voucher
{
    private Excursion excursion;
    private TransportType transporttype;
    public Voucher(VoucherFactory factory)
    {
        excursion = factory.CreateExcursion();
        transporttype = factory.CreateTransportType();
    }
    public void ShowRoute()
    {
        transporttype.ShowRoute();
    }
    public void ShowExcursionRoute()
    {
        excursion.GetExcursionRoute();
    }
}
}