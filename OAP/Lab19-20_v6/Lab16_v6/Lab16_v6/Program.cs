
using Lab16_v6;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Threading;

class Program
{


    static void Main(string[] args)
    {
        /*        Agency.travelVoucher vouch1 = new Agency.travelVoucher("tour1","country1");

                Agency.travelVoucher vouch2 = new Agency.travelVoucher("tour2", "country2");

                Agency.travelVoucher vouch3 = new Agency.travelVoucher("tour3", "country3");

                Agency.travelVoucher vouch4 = new Agency.travelVoucher("tour4", "country4");

                Agency.travelVoucher vouch5 = new Agency.travelVoucher("tour5", "country5");

                Agency.travelVoucher vouch6 = new Agency.travelVoucher("tour6", "country6");


                List<AccountManager.Account> accountDatabase = new List<AccountManager.Account>();

            List<Agency.travelVoucher> travelVouchers = new List<Agency.travelVoucher>();

                travelVouchers.Add(vouch1);
                travelVouchers.Add(vouch2);
                travelVouchers.Add(vouch3);
                travelVouchers.Add(vouch4);
                travelVouchers.Add(vouch5);
                travelVouchers.Add(vouch6);

                AccountManager.Account firstCustomerAccount = new AccountManager.Account();
                firstCustomerAccount.accounttype = 0;
                firstCustomerAccount.login = "account123";
                firstCustomerAccount.password = "password";

                firstCustomerAccount.selectedVoucher.name = "not selected";
                firstCustomerAccount.selectedVoucher.country = "not selected";

                Agency.AccountDatabase.Registration(firstCustomerAccount, accountDatabase);
                Console.WriteLine("---------------------");
        *//*        Agency.AccountDatabase.Login(firstCustomerAccount, accountDatabase);
                Console.WriteLine("---------------------");
                Agency.AccountDatabase.EnteringSystem(firstCustomerAccount, accountDatabase);*//*

                Agency.AccountDatabase.UserInterface(firstCustomerAccount, accountDatabase, travelVouchers);
        */

        // содаем объект пекаря



        // содаем объект Директор
        VoucherManager manager = new VoucherManager();
        // создаем класс-строитель
        FirstTypeVoucherBuilder builder = new FirstTypeVoucherBuilder();
        // передаём директору
        Voucher newVoucher = manager.CreateVoucher(builder);
        string vouch1 = newVoucher.ToString();
        Console.WriteLine(vouch1);

        SecondTypeVoucherBuilder builder2 = new SecondTypeVoucherBuilder();
        Voucher newVoucher2 = manager.CreateVoucher(builder2);
        string vouch2 = newVoucher2.ToString();
        Console.WriteLine("\n" + vouch2);
        Console.WriteLine("----------");


        af.Voucher airlinevoucher = new af.Voucher(new af.AirlineVoucher());
        airlinevoucher.ShowRoute();
        airlinevoucher.ShowExcursionRoute();
        Console.WriteLine();
        af.Voucher marinevoucher = new af.Voucher(new af.MarineVoucher());
        marinevoucher.ShowRoute();
        marinevoucher.ShowExcursionRoute();
        Console.WriteLine("----------");

        ProgramObject comp = new ProgramObject();
        comp.Launch("blue","times","12px");
        Console.WriteLine($"{comp.Interface.backgroundColor}\n {comp.Interface.font}\n {comp.Interface.size}");

        // у нас не получится изменить ОС, так как объект уже создан    
        comp.Interface = Interface.getInstance("red", "arial", "11px");
        Console.WriteLine($"{comp.Interface.backgroundColor}\n {comp.Interface.font}\n {comp.Interface.size}");

        Console.WriteLine("------------------");

        IVoucher vouch = new Excursion("Болгария",14,"Автобус");
        IVoucher clonnedvouch = vouch.Clone();
        
        vouch.GetInfo();
        clonnedvouch.GetInfo();



        Console.WriteLine("------------------");

        IVoucher shopping = new Shopping("Минск", 3, 5);
        IVoucher clonnedshopping = shopping.Clone();
        shopping.GetInfo();
        clonnedshopping.GetInfo();

        Console.WriteLine("------------------");
        //adapter

        Flyer pilot = new Flyer();

        Plane auto = new Plane();

        pilot.Travel(auto);

        Ship ship = new Ship();

        IVouchTransport shipTransport = new ShipToTransportAdapter(ship);

        pilot.Travel(shipTransport);

        Console.WriteLine("------------------");

        ExcursionTravel exc1 = new ExcursionTravel();
        ExtraExcursionTravel exc2 = new ExtraExcursionTravel(exc1);
        exc2 = new ExtraExcursionTravel(exc1);
        Console.WriteLine("Название: {0}", exc1.Name);
        Console.WriteLine("Цена: {0}", exc1.GetCost());
        Console.WriteLine(" . . . . . . . ");
        Console.WriteLine("Название: {0}", exc2.Name);
        Console.WriteLine("Цена: {0}", exc2.GetCost());

        Console.WriteLine("-------------");

        Commander commander = new Commander();
        Flight flightstate = new Flight();
        commander.SetCommand(new FlightOnCommand(flightstate));
        commander.ActivateFlight();
        commander.Undo();

        Console.WriteLine("--------------");

        FlightS plane = new FlightS(FlightState.PREPARATION);
        plane.StandingPlane();
        plane.StandingPlane();
        plane.FlyingPlane();
        plane.FlyingPlane();


        Console.WriteLine("--------------");

        Trip trip = new Trip(40, "Excursion",new GoByPlane());
        trip.GetTripInfo();
        trip.Movable = new GoByShip();
        trip.GetTripInfo();



    }






}




