using System.Text;

public class AirLine
{
    public string AirlineName { get; set; }
}
public class TicketBack
{ 
}
public class Excursions
{
    public string Excursion { get; set; }
}

public class Voucher
{
    public AirLine AirLine { get; set; }
    public TicketBack TicketBack { get; set; }
    public Excursions Excursions { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (AirLine != null)
            sb.Append(AirLine.AirlineName + "\n");
        if (TicketBack != null)
            sb.Append("Билет назад включен \n");
        if (Excursions != null)
            sb.Append("Экскурсии: " + Excursions.Excursion + " \n");
        else
        {
            sb.Append("Экскурсии не предусмотрены");
        }
        return sb.ToString();
    }
}

abstract public class VoucherBuilder
{
    public Voucher Voucher { get; private set; }
    public void CreateVoucher()
    {
        Voucher = new Voucher();
    }
    public abstract void SetAirLine();
    public abstract void SetTicketBack();
    public abstract void SetExcursions();
}
public class VoucherManager
{
    public Voucher CreateVoucher(VoucherBuilder VoucherBuilder)
    {
        VoucherBuilder.CreateVoucher();
        VoucherBuilder.SetAirLine();
        VoucherBuilder.SetTicketBack();
        VoucherBuilder.SetExcursions();
        return VoucherBuilder.Voucher;
    }
}

public class FirstTypeVoucherBuilder : VoucherBuilder
{
    public override void SetAirLine()
    {
        this.Voucher.AirLine = new AirLine { AirlineName = "American airline" };
    }

    public override void SetTicketBack()
    {
        this.Voucher.TicketBack = new TicketBack();
    }

    public override void SetExcursions()
    {

    }
}
// строитель для пшеничного хлеба
public class SecondTypeVoucherBuilder : VoucherBuilder
{
    public override void SetAirLine()
    {
        this.Voucher.AirLine = new AirLine { AirlineName = "Cape air" };
    }

    public override void SetTicketBack()
    {
        this.Voucher.TicketBack = new TicketBack();
    }

    public override void SetExcursions()
    {
        this.Voucher.Excursions = new Excursions { Excursion = "экскурсия по городу" };
    }
}
