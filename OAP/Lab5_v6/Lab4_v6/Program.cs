using System;
using System.Diagnostics;

class Program
{
    public static int factorial(int n)
    {
        //assert завершает программу сразу же после обнаружения некорректных данных, он позволяет быстро локализировать
        //и исправить баги в программе, которые привели к некорректным данным.



        Debug.Assert(n >= 0, "попытка найти факториал отрицательного числа");

        Debug.Assert(n <= 10, "слишком большое значение");

        if (n < 2)
        {
            return 1;
        }

        return factorial(n - 1) * n;
    }



    static void Main(string[] args)
    {
        try
        {
            WorkBook trycatchtest1 = new WorkBook { grade = 11, DateOfPublishing = 01032022, price = 333 };  //1)grade > 11 (2) price <0   (3)DOP <0 && > 2022


            /*  // (4)  0 divide 
            int fourthexc = 12;
            int fourthexc2 = fourthexc / 0;
            */


            //(5) indexoutofrange ?
            int[] massivefivethexc = new int[2];
            massivefivethexc[1] = 12;


        }
        catch (GradeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (PriceException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (DOPException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch
        {
            Console.WriteLine("возникла непредвидення ошибка");
        }
        finally
        {
            Console.WriteLine("обработка исключений завершена");
            Logger a = new Logger();
            a.date = DateTime.Now;
            a.consolelog();


        }


        Console.WriteLine(factorial(4));
    }



}



class GradeException : ArgumentOutOfRangeException
{
    public GradeException(string message)
        : base(message) { }
}

class PriceException : ArgumentException
{
    public PriceException(string message)
        : base(message) { }
}

class DOPException : Exception
{
    public DOPException(string message)
        : base(message) { }
}


public class Logger
{
    public DateTime date;

    public void consolelog()
    {
        Console.WriteLine(date);
    }



}








//-------------------------------






interface IPrintingInfo
    {
        
    void IsOpen(){  }

    void IsInStock() {}


    }


public struct CurrentOwner            
{
    string OwnerName;

    int TakeDate;  //YYYMMDD

    int ReturnDate; //YYYYMMDD

}


public enum BookCondition
{
  New = 1,
  Normal = 2,
  Old= 3
}




public partial class Publisher
{

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();

       
    }



}
abstract public class PrintedEdition :Publisher, IPrintingInfo  
{


    public override string ToString()
    {
        return base.ToString();

       
    }

    public abstract void IsInStock();
    
    

    public virtual string NameTypeInfo()
    {
        return "This is a printed edition";
    }


}
public class Book : PrintedEdition
        {
          public int DateOfPublishing { get; set; }
          public string Language { get; set; }
          public string name { get; set; }
          public string type { get; set; }
          public CurrentOwner ownerperson { get; set; }
          public BookCondition condition { get; set; }
          public int price { get; set; }

    public class Author 
            {
                string Name;
            }

            public class Owner 
            {
                string Name;
            }

    public override string ToString()
    {
        string info = base.ToString();

        return $"{info} название: {name} жанр: {type}";
    }

    public override string NameTypeInfo()
    {
        return $"книга: {name} относится к жанру: {type}";
    }

    public override void IsInStock()
    {
        Console.WriteLine("Книга есть в наличии");
    }


}

    public class Magazine : PrintedEdition
        {
          public int DateOfPublishing { get; set; }
          public string Language { get; set; }
          public string name { get; set; }
          public string type { get; set; }
          public CurrentOwner ownerperson { get; set; }
          public BookCondition condition { get; set; }
          public int price { get; set; }
            public class Author
            {
                string Name;
            }

            public class Owner
            {
                string Name;
            }

    public override string ToString()
    {
        string info = base.ToString();

        return $"{info} название: {name} жанр:{type}";
    }

    public override string NameTypeInfo()
    {
       return $"Журнал: {name} имеет тематику: {type}";
    }

    public override void IsInStock()
    {
        Console.WriteLine("Журнал издание есть в наличии");
    }
}

        public class WorkBook : PrintedEdition 
        {


        private int DOP;
          public int DateOfPublishing
    {
        get
        {
            return DOP;
        }
        set
        {
            if (Convert.ToString(value).Length!= 8)
                throw new DOPException("ошибка при указании даты:укажите дату в формате ДДММГГГГ");
            else
                DOP = value;
        }
    }
    public string Language { get; set; }
          public string name { get; set; }
    private int Grade;
    public int grade
          {
        get
        {
            return Grade;
        }
        set 
                {
            if (value > 11)
                throw new GradeException("Ошибка при указании класса учебника:значение должно быть <=11");
            else
                Grade = value;
        } 
          }
          public CurrentOwner ownerperson { get; set; }

    public BookCondition condition;


    private int Price;
        public int price
            {
            get
                {
                return Price;
                }
            set
                {
                if (value < 0)
                throw new PriceException("неверно указана стоимость учебника:стоимость не может быть отрицательной");
                else
                Price = value;
                }
        }
            public class Author
            {
                string Name;
            }

            public class Owner
            {
                string Name;
            }
    public override string ToString()
    {
        string info = base.ToString();

        return $"{info} предмет: {name} класс:{grade}";
    }

    public override void IsInStock()
    {
        Console.WriteLine("Учебник издание есть в наличии");
    }

    public override string NameTypeInfo()
    {
        return $"учебник по предмету: {name} для {grade} класса ";
    }

}

static class Printer
/*     Создайте дополнительный класс Printer c полиморфным методом
IAmPrinting(SomeAbstractClassorInterface someobj). Формальным
параметром метода должна быть ссылка на абстрактный класс или наиболее
общий интерфейс в вашей иерархии классов.В методе iIAmPrinting
определите тип объекта и вызовите ToString(). В демонстрационной    
программе создайте массив, содержащий ссылки на разнотипные объекты
ваших классов по иерархии, а также объект класса Printer и последовательно
вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов*/

{

    public static void IAmPrinting(PrintedEdition elem)
    {
        if (elem is Book bookitem)
        {
            Console.WriteLine(bookitem.ToString());
        }
        else if (elem is WorkBook workbookitem)
        {
            Console.WriteLine(workbookitem.ToString());
        }
        else if (elem is  Magazine magazineitem)
        {
            Console.WriteLine(magazineitem.ToString());
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}

public class a 
{ 

}

public class b : a
{

}








