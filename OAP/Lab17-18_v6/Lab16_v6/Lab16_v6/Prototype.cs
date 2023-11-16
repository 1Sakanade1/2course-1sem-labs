interface IVoucher
{
    IVoucher Clone();
    void GetInfo();
}

class Excursion : IVoucher
{
    string country;
    int duration;
    string transportType;
    public Excursion(string _country, int _dur, string _transport)
    {
        country = _country;
        duration = _dur;
        transportType = _transport;
    }

    public IVoucher Clone()
    {
        return new Excursion(this.country, this.duration,this.transportType);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Экскурсия в {country} будет длиться {duration} дней , тип транспорта:{transportType}");
    }
}

class Shopping : IVoucher
{
    string city;
    int duration;
    int amountOfShops;
    public Shopping(string _city, int _duration,int _amount)
    {
        city = _city;
        duration= _duration;
        amountOfShops = _amount;
    }

    public IVoucher Clone()
    {
        return new Shopping(this.city, this.duration, this.amountOfShops);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Шоппинг тур в городе {city}, длительность тура:{duration} дней, количество магазинов: {amountOfShops} ");
    }
}