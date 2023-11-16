using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16_v6
{
    internal class AccountManager
    {
        public struct Account
        {
            public string login;

            public string password;

            public int accounttype;  // 0 - customer | 1 - employee

            public Agency.travelVoucher selectedVoucher;

        }


    }
}
