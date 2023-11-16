using System;

namespace L1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявление и вывод двумерного массива
            Console.WriteLine("Двумерный массив: ");
            const int n = 2; //ширина массива
            const int m = 3; //высота
            int[,] massivintov = new int[n, m] { { 0, 1, 2 }, { 3, 4, 5 } };
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    Console.Write(massivintov[i, k] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Массив строк и работа с ним: ");
            Console.WriteLine();
            //объявление и работа над массивом строк

            const int l = 4;
            int massivlength = 0;
            string[] massivstrok = new string[l] { "abc", "zxc", "qwe", "asd" };
            Console.WriteLine("Элементы массива: ");
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(massivstrok[i]);
                massivlength = massivlength + massivstrok[i].Length;
            }
            Console.WriteLine();

            Console.WriteLine("Длинна массива:" + massivlength);
            Console.WriteLine();

            Console.WriteLine("введите номер элемента массива для замены (1-4)");
            int numbertochange = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите новую строку: ");
            massivstrok[numbertochange - 1] = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(massivstrok[i]);
            }

            Console.WriteLine();
            //Ступенчатые массивы
            //тип[] [] имя_массива = new тип [размер] [];
            int koef = 2;
            int[][] stupmassiv = new int[3][];// Объявление ступенчатого массива
            stupmassiv[0] = new int[2];
            stupmassiv[1] = new int[3];
            stupmassiv[2] = new int[4];

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < koef; k++)
                {
                    Console.WriteLine("введите значение элемента:"+(i+1)+" "+(k+1) );
                    stupmassiv[i][k] = Convert.ToInt32(Console.ReadLine());
                }
                koef++;
                Console.WriteLine();
            }
            koef = 2;
            Console.WriteLine("Ступенчатый массив:");
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < koef; k++)
                {
                    Console.Write(stupmassiv[i][k] + " ");
                }
                koef++;
                Console.WriteLine();
            }
            //неявно типизированная переменная для хранения массива и строки
            var massivvar = stupmassiv;
            var stringvar = "some text";
        }
    }
}
