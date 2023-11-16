using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Lab16_v6.Agency;

namespace Lab16_v6
{
    internal class Agency
    {
        public struct travelVoucher
        {
            public string name;
            public bool isburning;
            public string country;

            public travelVoucher(string _name, string _country)
            {
                this.name = _name;
                this.isburning= false;
                this.country = _country;

            }
        } 



        public class AccountDatabase
        {
            public static void Registration(AccountManager.Account account, List<AccountManager.Account> accountDatabase)
            {
                bool isAccountExists = true;

                foreach(AccountManager.Account databaseElem in accountDatabase) 
                {
                    if (databaseElem.login == account.login)
                    {
                        Console.WriteLine("Аккаунт с таким логином уже зарегестрирован");

                        isAccountExists = false;
                    }
                   
                }
        
                if(isAccountExists)
                {
                    accountDatabase.Add(account);
                    Console.WriteLine("регистрация прошла успешно!");
                }


            }

            public static bool Login(AccountManager.Account account, List<AccountManager.Account> accountDatabase)
            {


                foreach (AccountManager.Account databaseElem in accountDatabase)
                {
                    if (databaseElem.login == account.login && databaseElem.password == account.password)
                    {
                        Console.WriteLine($"Вы вошли в аккаунт {account.login}");
                        return true;
                    }
                }

                Console.WriteLine("Неверный логин или пароль");
                return false;

            }

            public static bool EnteringSystem(AccountManager.Account account, List<AccountManager.Account> accountDatabase)
            {
                bool isLoggined = false;

                Console.WriteLine("Выберите действиe : 1 - регистрация | 2 - логин");
                switch (Console.ReadLine())
                {
                    case "1":
                        AccountDatabase.Registration(account, accountDatabase);
                        break;

                    case "2":
                        isLoggined = AccountDatabase.Login(account, accountDatabase);
                        break;
                }

                return isLoggined;

            }


            public static void VouchersOut(List<Agency.travelVoucher> travelVouchers)
            {
                int counter = 1;

                foreach(travelVoucher elem in travelVouchers)
                {
                    Console.WriteLine(counter + ": " + elem.name +" "+ elem.country);

                    counter++;
                }
            }

            public static void BurningVouchersOut(List<Agency.travelVoucher> travelVouchers)
            {
                foreach (travelVoucher elem in travelVouchers)
                {
                    if(elem.isburning) { 
                    Console.WriteLine(elem);
                    }
                }


            }

            public static void AddVoucher(Agency.travelVoucher voucher, List<Agency.travelVoucher> travelVouchers)
            {
                travelVouchers.Add(voucher);
                Console.WriteLine("путевка успешно добавлена");
            }

            public static void MakeVoucherBurning(Agency.travelVoucher voucher, List<Agency.travelVoucher> travelVouchers)
            {
                bool iselemfound = false;

                foreach(Agency.travelVoucher elem in travelVouchers)
                {
                    if(elem.name == voucher.name)
                    {
                        voucher.isburning = true;
                        travelVouchers.Remove(elem);
                        travelVouchers.Add(voucher);
                        iselemfound = true;

                      
                    }

                    if(!iselemfound)
                    {
                        Console.WriteLine("Путевка не была найдена");
                    }
                    else
                    {
                        Console.WriteLine("Путевка успешно помечена как горящая");
                    }

                }


            }

            public static void SelectVoucher(AccountManager.Account account, List<Agency.travelVoucher> travelVouchers)
            {
                Console.WriteLine(account.selectedVoucher.name);

                if (account.selectedVoucher.name == "not selected" && account.selectedVoucher.country == "not selected")
                {

                    VouchersOut(travelVouchers);
                    Console.WriteLine("выберите номер путёвки,которую хотите добавить:");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    account.selectedVoucher = travelVouchers[selection - 1];
                    travelVouchers.Remove(travelVouchers[selection-1]);
                }
                else
                {

                    Console.WriteLine("у вас уже есть активная путевка,сначала отмените её");

                }

            }

            public static void CurrentUserVoucherOut(AccountManager.Account account)
            {
                if (account.selectedVoucher.name == "not selected" && account.selectedVoucher.country == "not selected")
                {
                    Console.WriteLine("Вы не выбрали путевку");
                }
                else
                {
                    Console.WriteLine(account.selectedVoucher.name + account.selectedVoucher.country);
                }
            }

            public static void VoucherCancellation(AccountManager.Account account, List<Agency.travelVoucher> travelVouchers)
            {
                travelVouchers.Add(account.selectedVoucher);

                account.selectedVoucher.name = "not selected";
                account.selectedVoucher.country = "not selected";

                Console.WriteLine("ваша путёвка успешно отменена");

            }

            public static void AddNewVoucher(List<Agency.travelVoucher> travelVouchers)
            {
                Agency.travelVoucher vouchtoadd = new Agency.travelVoucher("addedVouch","some_country");

                travelVouchers.Add(vouchtoadd);
                Console.WriteLine("Новая путёвка успешно добавлена");

            }

            

            public static void UserInterface(AccountManager.Account account, List<AccountManager.Account> accountDatabase, List<Agency.travelVoucher> travelVouchers)
            {
                bool isloginned = EnteringSystem(account, accountDatabase);

                if (isloginned)
                {
                    Console.WriteLine("Вы вошли в аккаунт");

                    switch (account.accounttype)
                    {
                        

                        case 0: //customer

                            Console.WriteLine("выберите действие: 1 - просмотр доступных путёвок \n 2 - выбор путёвки \n 3 - просмотр моей путевки \n 4 - отмена путёвки \n 5 - выход из системы ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            bool key1 = true;
 
                            switch (choice)
                            {
                                case 1:
                                    VouchersOut(travelVouchers);
                                    break;

                                case 2:
                                    SelectVoucher(account, travelVouchers);
                                    break;

                                case 3:
                                    CurrentUserVoucherOut(account);
                                    break;

                                case 4:
                                    VoucherCancellation(account, travelVouchers);
                                    break;


                            }
                            
                            break;


                        case 1: //employee

                            Console.WriteLine("выберите действие: 1 - просмотр списка путёвок \n 2 - добавление новой путёвки в список \n 3 - определить тур как горящий \n 4 - выход из системы \n ");
                            int choice2 = Convert.ToInt32(Console.ReadLine());
                            bool key2 = true;
                                switch (choice2)
                            {
                                case 1:
                                    VouchersOut(travelVouchers);
                                    break;

                                case 2:
                                    AddNewVoucher(travelVouchers);
                                    break;

                                case 3:
                                    Agency.travelVoucher voucherToMakeBurning= new Agency.travelVoucher("tour3","country3");
                                    MakeVoucherBurning(voucherToMakeBurning, travelVouchers);
                                    break;
                            }
                            





                            break;




                    }
                }
                else
                {
                    Console.WriteLine("Не удалось войти в аккаунт");
                }


            }

        }


        public class OffersManager
        {






        }



    }
}
