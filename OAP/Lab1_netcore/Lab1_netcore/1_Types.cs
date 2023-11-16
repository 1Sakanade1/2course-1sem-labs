using System;

namespace Lab1_netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 zadanie

            Console.WriteLine("Enter int value");
            int inttest = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entered int is" + " " + inttest);

            Console.WriteLine("Enter bool value");
            bool booltest = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Entered bool is" + " " + booltest);

            Console.WriteLine("Enter byte value");
            byte bytetest = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Entered byte is" + " " + bytetest);

            Console.WriteLine("Enter sbyte value");
            sbyte sbytetest = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Entered sbyte is" + " " + sbytetest);

            Console.WriteLine("Enter char value");
            char chartest = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Entered char is" + " " + chartest);

            Console.WriteLine("Enter decimal value");
            decimal decimaltest = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Entered decimal is" + " " + decimaltest);

            //2 zadanie

            //Для встроенных числовых типов неявное преобразование можно выполнить, если сохраняемое значение может уместиться в переменной без усечения или округления
            //primer neyavnogo
            int num = 2147483647;
            long bigNum = num;



            //Тем не менее если преобразование нельзя выполнить без риска потери данных, компилятор требует выполнения явного преобразования, которое называется приведением
            //primer yavnogo
            double x = 1234.7;
            int a;
            // Cast double to int.
            a = (int)x;

            //3 zadanie 

            //Когда любой значимый тип присваивается к ссылочному типу данных, значение перемещается из области стека в кучу. Эта операция называется упаковкой.
            //Когда любой ссылочный тип присваивается к значимому типу данных, значение перемещается из области кучи в стек.Это называется распаковкой.

            //boxing
            int i = 123;
            object o = i;

            //unboxing

            o = 1234;
            i = (int)0;

            //4 zadanie
            // ispolzuetsia keyword "var"
            //Это возможно только внутри метода, а не на уровне класса, где всегда необходимо указывать Тип.

            Console.WriteLine("Enter int number");
            var vartest = Console.ReadLine();
            int z4 = 123 ;

            vartest = vartest + z4;

            //5 zadanie
            int? z5 = null;  //если значение в базе данных есть - получим число, если нет - то null.
            Console.WriteLine("znachenie pri z5=null");
            Console.WriteLine(z5);
            z5 = 5;
            Console.WriteLine("znachenie pri z5=5");
            Console.WriteLine(z5);




        }
    }
}
