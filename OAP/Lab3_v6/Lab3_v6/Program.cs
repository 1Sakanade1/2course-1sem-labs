using System;

public class Node
{
  public object Data { get; set; }
 
    public Node next { get; set; }

};

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

  

    public static string operator + (List element, int position)//добавить элемент в заданной позиции
    {
        Console.WriteLine("enter elemnt data");
        Node Datatopaste = new Node();
        Datatopaste.Data = Console.ReadLine();

        Node current = element.Head;
        for (int i = 1; i < position; i++) 
        {

            current = current.next;
        }
        Node cont = current.next;
        current.next = new Node() { Data = Datatopaste.Data };
        current.next.next = cont;

        return ($"объект {Datatopaste.Data} успешно добавлен в позицию {position}");
    }

    public static string operator >>(List element, int position)//удалить элемент в позиции
    {
        Node current = element.Head;
        {
            for (int i = 1; i < position-2; i++)// идем до элемента,стоящего перед тем,который необходимо удалить
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


    public void AddToEnd(object data)//добавление элемента в конец списка
    {
        if (Head == null)
        {
            Head = new Node() { Data = data };
        }
        else
        {
            Node current = Head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node() { Data = data };
        }


    }

    public void AddToPosition(object data, int position)//добавление элемента в определенную позицию
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
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.next;
        }
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




    public static bool operator !=(List elem1, List elem2)//сравнить списки 
    {
        int firstlength = elem1.Length();
        int secondlength = elem2.Length();

        Node current1 = new Node();
        current1 = elem1.Head;

        Node current2 = new Node();
        current2 = elem2.Head;

        if (firstlength != secondlength)
        {
            return true;
        }
        for (int i = 0; i < firstlength; i++)
        {
            if (current1 != current2)
            {
                return true;
            }
            current1 = current1.next;
            current2 = current2.next;
        }
        return false;
    }

    public static bool operator ==(List elem1, List elem2) //сравнить списки
    {
        int firstlength = elem1.Length();
        int secondlength = elem2.Length();

        Node current1 = new Node();
        current1 = elem1.Head;

        Node current2 = new Node();
        current2 = elem2.Head;

        if (firstlength != secondlength)
        {
            return false;
        }
        for (int i = 0; i < firstlength; i++)
        {
            if (current1 != current2)
            {
                return false;
            }
            current1 = current1.next;
            current2 = current2.next;
        }
        return true;
    }



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



public static class StatisticOperation
{
    public static int AllElementsSum(List element)// сумма всех элементов
    {

        Node current = element.Head;

        int counter = 0;

        for (int i = 0; i < element.Length(); i++)
        {
            counter = counter + Convert.ToInt32(current.Data);
            current = current.next;
        }

        return counter;
    }

    public static int Maxminusmin(List element)// разница между максимальным и минимальными элементами
    {
        Node current = element.Head;

        int max = Convert.ToInt32(current.Data);
        int min = Convert.ToInt32(current.Data);

        int result;

        for (int i = 0; i < element.Length(); i++)
        {
            if (Convert.ToInt32(current.Data) > max)
            {
                max = Convert.ToInt32(current.Data);
            }
            if (Convert.ToInt32(current.Data) < min)
            {
                min = Convert.ToInt32(current.Data);
            }

            current = current.next;
        }

        result = max - min;

        return result;
    }

    public static int StaticLength(List element)  //подсчет количества элементов
    {
        return element.Length();
    }

    public static void stringout(this string str)
    {
        Console.WriteLine(str);
    }

    public static void OutElementByNumber(this List element)
    {
        Console.WriteLine("введите номер элемента,который вы хотите вывести");
        int ctr = Convert.ToInt32(Console.ReadLine());

        Node current = element.Head;

        for(int i = 1; i < ctr; i++)
        {
            current = current.next;
        }
        Console.WriteLine("значение этого элемента: " + current);
    }
}







namespace Lab3_v6
{
    class Program
    {
        static void Main(string[] args)
        {
            List a = new List();
            a.AddToEnd("1");
            a.AddToEnd("2");
            a.AddToEnd("3");
            a.AddToEnd("4");
            a.AddToEnd("5");
            /*         a.AddToEnd("4");
                     a.AddToPosition("u7", 3);
                     Console.WriteLine(a + 2);*/
            Console.WriteLine(a >> 2);
            a.ListOut();
            Console.WriteLine(" ");
            List a2 = new List();
            a2.AddToEnd("1");
            a2.AddToEnd("2");
            a2.AddToEnd("4");
            a2.AddToEnd("4");
            a2.AddToPosition("7", 3);
            a2.ListOut();
            StatisticOperation.AllElementsSum(a);

            Console.WriteLine(a != a2);

            List.Production prod = new List.Production();

            prod.ID = 120;
            prod.OrgName = "BSTU";

            List.Developer dev = new List.Developer();

            dev.FIO = "Sviatoslav";
            dev.ID = 121;
            dev.Otdel = "POIT";

            string teststr = "text";
            teststr.stringout();


        }
    }
}
