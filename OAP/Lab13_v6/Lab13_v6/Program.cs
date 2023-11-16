using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Lab13_v6;
using System.Xml;
using System.Xml.Linq;

public class Program
{
    public static async void writejs(Book book)
    {
        using (FileStream fs = new FileStream("Bookjs.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Book>(fs, book);
            Console.WriteLine("Data has been saved to file");
            fs.Close();
        }



    }

    public static async void writejsmas(Book[] books)
    {


        using StreamWriter sw = new StreamWriter("Book2.json", true);
        var data = JsonSerializer.Serialize(books);
        sw.WriteLine(data);


    }

    public static async void readjs()
    {
        using (FileStream fs = new FileStream("Bookjs.json", FileMode.OpenOrCreate))
        {
            Book newbook = await JsonSerializer.DeserializeAsync<Book>(fs);
            Console.WriteLine($"Name: {newbook?.name}  Type: {newbook?.type}");
        }


    }


    public static void JsonDeserializion()
    {
        using StreamReader sr = new StreamReader("Book2.json");


        var data = sr.ReadLine();
        var test = JsonSerializer.Deserialize<List<Book>>(data);

        var list = new List<Book>(test);


        foreach (var item in list)
        {
            Console.WriteLine(item);
        }






    }





    static void Main(string[] args)
    {
        Book Musketeers = new Book();
        Musketeers.name = "Три мушкетера";
        Musketeers.type = "Приключение0";
        Musketeers.pages = 400;

        Book AmericanTragedy = new Book();
        AmericanTragedy.name = "Американская трагедия";
        AmericanTragedy.type = "роман";
        AmericanTragedy.pages = 672;

        Book Idiot = new Book();
        Idiot.name = "Идиот";
        Idiot.type = "роман";
        Idiot.pages = 640;

        WorkBook Physics = new WorkBook();
        Physics.name = "Физика";
        Physics.grade = 9;





        Console.WriteLine("--------Binary--------");
        BinaryFormatter formatter = new BinaryFormatter();

        Serializator.binser("Books.dat", Musketeers);

        Serializator.bindeser("Books.dat");


        //xml
        Console.WriteLine("---------xml---------");

        Serializator.xmlser("Book.xml", Musketeers);

        Serializator.xmldeser("Book.xml");



        //json
        Console.WriteLine("---------json---------");

        Serializator.jsonser("Book.json", Musketeers);
        Serializator.jsondeser("Book.json");


        //zadanie 2
        Console.WriteLine("---------z2---------");
        
        List<Book> library = new List<Book>();

        library.Add(Idiot);
        library.Add(Musketeers);
        library.Add(AmericanTragedy);

        Book[] books = new Book[] { Musketeers, Idiot, AmericanTragedy };

        Serializator.binwork("Books2.bin", books);


        //xml селекторы

        Console.WriteLine("------------------");

        //выберем все узлы корневого элемента, то есть все элементы  Book:
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("Book.xml");
        XmlElement xRoot = xDoc.DocumentElement;

        XmlNodeList childnodes = xRoot.SelectNodes("*");
        foreach (XmlNode n in childnodes)
            Console.WriteLine(n.OuterXml);


        Console.WriteLine("-------------------");

        //Выведем на консоль значения атрибутов name у элементов Book:
        XmlNodeList childnode = xRoot.SelectNodes("name");

        foreach (XmlNode elem in childnode)
        {
            Console.WriteLine(elem);
        }

        Console.WriteLine(childnode);


        Console.WriteLine("-------------------");

        //Допустим, нам надо получить только тип .Для этого надо осуществить выборку вниз по иерархии элементов:
        XmlNodeList childnod = xRoot.SelectNodes("//Book/type");
        foreach (XmlNode n in childnod)
            Console.WriteLine(n.InnerText);

        Console.WriteLine("----------------");
        Console.WriteLine("4 zadanie");


        XDocument xdoc = new XDocument();
        // создаем первый элемент
        XElement Book = new XElement("Book");
        // создаем атрибут
        XAttribute BookName = new XAttribute("name", "Idiot");
        XElement BookAuthor = new XElement("Author", "Dostoevskii");
        XElement BookPrice = new XElement("price", "40000");
        Book.Add(BookName);
        Book.Add(BookAuthor);
        Book.Add(BookPrice);

        XElement WorkBook = new XElement("WorkBook");
        XAttribute WorkBookName = new XAttribute("name", "Math");
        XElement WorkBookAuthor = new XElement("Author", "workbookAuthor");
        XElement WorkBookPrice = new XElement("price", "15000");
        WorkBook.Add(WorkBookName);
        WorkBook.Add(WorkBookAuthor);
        WorkBook.Add(WorkBookPrice);

        XElement BookLastTask = new XElement("PrintExemplar");
        BookLastTask.Add(Book);
        BookLastTask.Add(WorkBook);
        // добавляем корневой элемент в документ
        xdoc.Add(BookLastTask);
        //сохраняем документ
        xdoc.Save("BookLastTask.xml");


        Console.WriteLine("запрос linq to xml");


        XDocument xdocwork = XDocument.Load("BookLastTask.xml");
        // получаем корневой узел
        XElement? PrintExemplar = xdocwork.Element("PrintExemplar");

            // проходим по всем элементам PrintExemplar
            foreach (XElement book in PrintExemplar.Elements("Book"))
            {

                XAttribute? name = book.Attribute("name");
                XElement? Author = book.Element("Author");
                XElement? price = book.Element("price");

                Console.WriteLine($"PrintExemplar: {name?.Value}");
                Console.WriteLine($"Author: {Author?.Value}");
                Console.WriteLine($"price: {price?.Value}");

                Console.WriteLine(); //  для разделения при выводе на консоль
            }
        

    }
}