using System;

namespace L1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            (int,int,char) Func1(int[] massiv, string stroka,int massivlength)
            {
                (int, int, char) kortej;
                int massivmaxnumber=massiv[0];
                int massivminnumber=massiv[0];
                int sumofnumbers = 0;

                //рассчитываем min и max элементы
                for(int i = 1; i < 3; i++)
                {
                    if (massivmaxnumber < massiv[i])
                    {
                        massivmaxnumber = massiv[i];
                    }

                    if (massivminnumber > massiv[i])
                    {
                        massivminnumber = massiv[i];
                    }

                }
                //рассчитываем сумму всех элементов
                for(int i = 0; i < 3; i++)
                {
                    sumofnumbers = sumofnumbers + massiv[i];
                }

                kortej = (massivmaxnumber, massivminnumber, stroka[0]);
                return kortej;

            };

            const int massivlength = 3;

            int[] massivintov = new int[massivlength] { 1, 2, 3 };
            string stroka = "zxc";

            //результат работы функции
            Console.WriteLine(Func1(massivintov, stroka, massivlength));


        }
    }
}
