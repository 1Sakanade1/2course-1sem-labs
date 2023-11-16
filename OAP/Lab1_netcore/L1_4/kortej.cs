using System;

namespace L1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //задаём кортеж
            (int, string, char, string, ulong) t1 = (1, "hello", 'a', "world", 12);
            Console.WriteLine(" ");
            //вывод всех элементов кортежа:
            Console.WriteLine(t1);
            //выборочный вывод элементов:
            Console.WriteLine("Первый и третий элементы кортежа: " + t1.Item1 + " " + "," + " " + t1.Item3);
            //деконструкция кортежей:
            int dekonstint;
            string dekonststring1;
            char dekonstchar;
            string dekonststring2;
            ulong dekonstulong;
            (dekonstint, dekonststring1, dekonstchar, dekonststring2, dekonstulong) = t1;
            Console.WriteLine(" ");
            Console.WriteLine(" Переменные, содержащие элементы кортежа: ");
            Console.WriteLine(dekonstint + " " + dekonststring1 + " " + dekonstchar + " " + dekonststring2 + " " + dekonstulong);

            //сравнение кортежей:
            var tuple1 = (23, 36);
            var tuple2 = (17, 31);
            Console.WriteLine(" ");
            //при сравнении кортежей все элементы кортежа должны иметь возможности сравнения
            //кол-во элементов должно быть одинаковым
            Console.WriteLine(tuple1 == tuple2);//False
            Console.WriteLine(tuple1 != tuple2);//True

        }
    }
}
