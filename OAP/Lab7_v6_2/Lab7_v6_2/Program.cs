using System;

using System.Collections.Generic;

using System.IO;

interface ITasks<I>
{
    void Add(I item);

    void Remove(I item);

    void Out();
}

public class CollectionType<T> :  ITasks<T> 
{
    public List<T> Spisok = new List<T>();


    public void Add(T item)
    {
        Spisok.Add(item);
    }

    public void Remove(T item)
    {
        Spisok.Remove(item);
    }

    public void Out()
    {
        foreach (T item in Spisok)
        {
            Console.WriteLine(item);
        }
    }

    public void WriteInFile()
    {
        string strtowrite = null;
        if (File.Exists("C:\\Lab\\Lab7.txt"))
        {
            foreach (T item in Spisok)
            {
                strtowrite += Convert.ToString(item) + " | ";
            }
            File.WriteAllText("C:\\Lab\\Lab7.txt", strtowrite);

        }
    }

}


public class PersonInfo 
{
    public PersonInfo(string name, string secondname)
    {
        Name = name ;
        SecondName = secondname ;
    }

    public string Name { get; set; }
    public string SecondName { get; set; }
}






namespace Lab7_v6_2
{
    class Program
    {
        static void Main(string[] args)
        {

            CollectionType<string> strspis = new CollectionType<string>();
            strspis.Add("zxc");

            strspis.Add("qwe");

            strspis.Out();

            PersonInfo employee1 = new PersonInfo("Edward","Norton");
            employee1.Name = "Edward";

            PersonInfo employee2 = new PersonInfo("Robert", "Paulson");


            CollectionType<PersonInfo> spisok = new CollectionType<PersonInfo>();


            Console.WriteLine(employee1);

            spisok.Add(employee1);

            spisok.Add(employee2);

            spisok.Out();

            strspis.WriteInFile();


            //read from file
            if (File.Exists("C:\\Lab\\Lab7.txt"))
            {
                string info = File.ReadAllText("C:\\Lab\\Lab7.txt");
                Console.WriteLine(info);
            }


        }
    }
}
