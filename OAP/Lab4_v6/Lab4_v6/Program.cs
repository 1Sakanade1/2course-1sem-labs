using System;

interface IPrintingInfo
    {
        
    void IsOpen(){  }

    void IsInStock() {}


    }




public class Publisher
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
    
    

    public virtual void NameTypeInfo()
    {

    }


}
public class Book : PrintedEdition
        {
          public int DateOfPublishing { get; set; }
          public string Language { get; set; }
          public string name { get; set; }
          public string type { get; set; }

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

    public override void NameTypeInfo()
    {
        Console.WriteLine($"книга: {name} относится к жанру: {type}");
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

    public override void NameTypeInfo()
    {
        Console.WriteLine($"Журнал: {name} имеет тематику: {type}");
    }

    public override void IsInStock()
    {
        Console.WriteLine("Журнал издание есть в наличии");
    }
}

        public class WorkBook : PrintedEdition 
        {

          public int DateOfPublishing { get; set; }
          public string Language { get; set; }
          public string name { get; set; }
          public int grade { get; set; }

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

    public override void NameTypeInfo()
    {
        Console.WriteLine($"учебник по предмету: {name} для {grade} класса ");
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


namespace Lab4_v6
{
    class Program
    {
        static void Main(string[] args)
        {
            Book a = new Book();
            a.name = "Три мушкетера";
            a.type = "Приключение";

            WorkBook b = new WorkBook();
            b.name = "Физика";
            b.grade = 9; 
            a.IsInStock();
            a.NameTypeInfo();
            b.NameTypeInfo();
            Console.WriteLine();
            b zxc = new b();
            a? test = zxc as b;
            if (test == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Элемент был удачно преобразован");
            }


            a zxc2 = new a();
            b? test2 = zxc as b;
            if (test2 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Элемент был удачно преобразован");
            }

            Console.WriteLine();

            PrintedEdition[] Arr = { a, b};
            for (int i = 0; i < 2; i++)
            {
                Printer.IAmPrinting(Arr[i]);
            }

        }
    }
}
