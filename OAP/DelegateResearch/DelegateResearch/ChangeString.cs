using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateResearch
{

    public  delegate string StringChanger(string str);
    public class ChangeString
    {
        




       
        public static string Lower(string str)
        {
            Console.WriteLine("Lower - " + str.ToLower());
            return str.ToLower();
        }

        public static string Upper(string str)
        {
            Console.WriteLine("Upper - " + str.ToUpper());
            return str.ToUpper();
        }

        public static string Remove(string str)
        {
            Console.WriteLine("Remove - " + str.Remove(0, 1));
            return str.Replace(" ", "");
        }

        public static string Add(string str)
        {
            str += "!";

            Console.WriteLine("Add - " + str);

            return str;
        }



    }
}
