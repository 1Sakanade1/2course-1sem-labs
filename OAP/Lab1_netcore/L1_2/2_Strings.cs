using System;
using System.Text;

namespace L1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //z1 объявить две строки и сравнить

            string s1 = "strstr";
            string s2 = "strstr";

            //метод String.Compare сравнивает строки по алфавиту, если строки равны,то возвращает 0
            // Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля. В противном случае возвращается число больше нуля
            int result = string.Compare(s1, s2);
            if (result < 0)
            {
                Console.WriteLine("Строка s1 перед строкой s2");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка s1 стоит после строки s2");
            }
            else
            {
                Console.WriteLine("Строки s1 и s2 идентичны");
            }
            // результатом будет "Строка s1 и s2 идентичны"

            //z2 Создайте три строки на основе String. Выполните: сцепление,
            //копирование, выделение подстроки, разделение строки на слова,
            //вставки подстроки в заданную позицию, удаление заданной
            //подстроки.
            Console.WriteLine("-------------------------------------- z2");
            string z2s1="zxc";
            string z2s2= "qwe";
            string z2s3= "???";

            //сцепление

            string[] values = new string[] { z2s1, z2s2, z2s3 };
            string z2joined = string.Join(" ", values);
            Console.WriteLine(z2joined);

            Console.WriteLine("--------------------------------------");
            //копирование
            string tocopy="String to copy";
            string copyingstring = String.Copy(tocopy);
            Console.WriteLine(copyingstring);

            Console.WriteLine("--------------------------------------");
            //выделение подстроки
            string videlenie = z2joined.Substring(4, 3);
            Console.WriteLine(videlenie);

            Console.WriteLine("--------------------------------------");
            //разделение строки на слова
            string[] words = z2joined.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for(int i=0;i<3;i++)
            Console.WriteLine(words[i]);

            Console.WriteLine("--------------------------------------");
            //вставка подстроки
            string substring = " Hello world! ";

            string insertedstring = z2joined.Insert(4, substring);
            Console.WriteLine(insertedstring);  

            Console.WriteLine("--------------------------------------");
            //удаление подстроки
           string deletedpartstring = z2joined.Remove(0, 4);
            Console.WriteLine(deletedpartstring);
            Console.WriteLine("--------------------------------------");
            //интерполяция строки
            int x = 8;
            int y = 7;
            string interpres = $"{x} + {y} = {x + y}";
            Console.WriteLine(interpres); // 8 + 7 = 15

            //z3
            string emptystr = "";
            string nullstr = null;

            //IsNullOrEmpty() метод Стандартное решение для определения того, является ли строка пустой или нулевой,
            //использует String. IsNullOrEmpty() метод.Он возвращается true если указанная строка является нулевой или пустой строкой; в противном случае, false.
            String.IsNullOrEmpty(nullstr); // res - true
            String.IsNullOrEmpty(emptystr);// res - true
            Console.WriteLine("результат работы IsNullOrEmpty с NULL строкой : " + String.IsNullOrEmpty(nullstr));
            //z4

            //создание через стринг билдер
            StringBuilder sb = new StringBuilder("Привет мир");
            //удаление символов
            sb.Remove(7, 3);
            Console.WriteLine(sb);// "Привет"
            //возможный вариант добавления в конец строки
            sb.Append('c');
            Console.WriteLine(sb);// "Приветc"
            //добавление в начало строки
            sb.Insert(0, "Всем ");
            Console.WriteLine(sb);// "Всем Приветc"
        }
    }
}
