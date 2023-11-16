using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IPrintingInfo
{

    void IsOpen() { }

    void IsInStock() { }


}



[Serializable]
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
[Serializable]
abstract public class PrintedEdition : Publisher, IPrintingInfo
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

[Serializable]
public class Book : PrintedEdition
{

    public int DateOfPublishing { get; set; }
    public string Language { get; set; }
    public string name { get; set; }
    public string type { get; set; }

    [NonSerialized]
    public int pages;

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
