using Lab16_v6;

class Program
{


    static void Main(string[] args)
    {
        Agency.travelVoucher vouch1 = new Agency.travelVoucher("tour1","country1");

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
/*        Agency.AccountDatabase.Login(firstCustomerAccount, accountDatabase);
        Console.WriteLine("---------------------");
        Agency.AccountDatabase.EnteringSystem(firstCustomerAccount, accountDatabase);*/

        Agency.AccountDatabase.UserInterface(firstCustomerAccount, accountDatabase, travelVouchers);



    }


}

