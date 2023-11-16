using System;

public class Node
{
    public string Data { get; set; }

    public Node next { get; set; }

    public int Price { get; set; }

    public int Year { get; set; }
}


public class List
{
    public Node Head { get; set; }



    public class Production
    {
        public int ID;
        public string OrgName;
    }

    public class Developer
    {
        public string FIO;
        public int ID;
        public string Otdel;
    }



    public static string operator >>(List element, int position)//удалить элемент в позиции
    {
        Node current = element.Head;
        {
            for (int i = 1; i < position - 2; i++)// идем до элемента,стоящего перед тем,который необходимо удалить
            {

                current = current.next;
            }
            if (position < element.Length())
            {
                current.next = current.next.next;
            }
            else
            {
                current.next = null;
            }
        }
        return ($"Элемент номер {position} удалён");
    }


    public void AddToEnd(string data,int price=0,int year=0)//добавление элемента в конец списка
    {
        if (Head == null)
        {
            Head = new Node() { Data = data, Price = price,Year = year };
        }
        else
        {
            Node current = Head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node() { Data = data, Price = price, Year = year };
        }


    }

    public void AddToPosition(string data, int position)//добавление элемента в определенную позицию
    {

        if (Head == null)
        {
            Head = new Node() { Data = data };
        }
        else
        {
            Node current = Head;
            for (int i = 1; i < position; i++)
            {

                current = current.next;
            }
            Node cont = current.next;
            current.next = new Node() { Data = data };
            current.next.next = cont;
        }


    }

    public void ListOut()//вывод списка
    {
        Node current = Head;
        while (current.next != null)
        {
            Console.WriteLine(current.Data);
            current = current.next;
        }
        Console.WriteLine(current.Data);
    }



    public int Length()// подсчет длинны списка
    {
        int counter = 0;
        Node current = Head;
        while (current != null)
        {
            current = current.next;
            counter++;
        }
        return counter;
    }




}


public  class controller :Publisher
{
  public  void amountofexemplars(List list)
    {
        Console.WriteLine("Количество экземпляров в библиотеке:  " + list.Length());
    }

    public int PriceOut(List list)//вывод списка
    {
        int counter = 0;
        Node current = list.Head;


        for(int i = 0; i < list.Length(); i++)
        {
            counter = counter + current.Price;
            current = current.next;  
        }


        Console.WriteLine("стоимость всех экземляров: "+ counter);
        return counter;
    }

    public void yearserch(List list)
    {
        Console.WriteLine("введите год");
        int y = Convert.ToInt32(Console.ReadLine());
        Node current = list.Head;
        for (int i = 0; i < list.Length(); i++)
        {
            if (current.Year >= y)
            {
                Console.WriteLine(current.Data);
            }
            current = current.next;
        }
    }


}








public partial class publisher
{
    public publisher next { get; set; }
}






/*class Program
{
    static void Main()
    {
        Book a = new Book();

        a.name = "Три Мушкетёра ";
        a.type = "Приключение";
        a.price = 123;
        a.DateOfPublishing = 2022;

        Book b = new Book();

        b.name = "Красавица и чудовище";
        b.type = "Сказка";
        b.price = 1213;
        b.DateOfPublishing = 2009;


        List library = new List();
        library.AddToEnd(a.NameTypeInfo(),a.price,a.DateOfPublishing);

        library.AddToEnd(b.NameTypeInfo(), b.price, b.DateOfPublishing);

        library.ListOut();




        controller contr = new controller();

        contr.amountofexemplars(library);

        Console.WriteLine();

        contr.PriceOut(library);

        Console.WriteLine();

        contr.yearserch(library);
    }
     






}*/