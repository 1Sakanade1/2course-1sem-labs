using System.Collections.Generic;

public partial class Book
{
    private static readonly string language;  // поле только для чтения (присвоение значения полю может происходить только при объявлении или в конструкторе этого класса.)
    private static int id { get; set; }
    public string name { get; set; }
    public string author { get; set; }
    private string publisher { get; set; }
    private int Year = 1;
    static private int amount = 0;
   public int pages { get; set; }    
   public int price { get; set; }
    public int year
    {
        set
        {
            if (value < 0 || value > 2022)
                Console.WriteLine("неверно указан год");
            else Year = value;
        }
        get { return Year; }
    }
    private bool pereplet;

    /*   public Book()
       {
           name = "unnamed book";
           author = "unknown";
           publisher = "unknown";
       }
   */
    public Book(int i, string na, string au, int yr, int _pages, int _price)// id name author year
    {
        amount++;
        id = i;
        name = na;
        author = au;
        publisher = "unknown";
        year = yr;
        pages = _pages;
        price = _price;
    }

    public Book(int i, string na, string au, string pub, int yr, int _pages, int _price)
    {
        amount++;
        id = i;
        name = na;
        author = au;
        publisher = pub;
        year = yr;
        pages = _pages;
        price = _price;

    }

    static Book()
    {
        language = "russian";
        amount = amount++;
    }


    private Book() { }

    static void GiveShortInfo(Book a)
    {
        Console.WriteLine("Название" + a.name);
        Console.WriteLine("Автор" + a.author);
        Console.WriteLine("Издатель" + a.publisher);

    }

    public int ChangeYear(ref Book book)
    {

        Console.WriteLine("Введите год написания книги");
        book.year = Convert.ToInt32(Console.ReadLine());
        return id;
    }

    public void UnauthorizeBook(out string name)
    {



        name = "unauthorized_book";

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

    ~Book()
    {
        Console.WriteLine($"Объект {Book.id}был удален");
    }


    public void AuthorsBooks(Book[] Books)
    {

        Console.WriteLine("Поиск по автору: ");

        string authorsearch = Console.ReadLine();

        Book[] ReturnBooks = new Book[Books.Length];

        int counter = 0;
        for (int i = 0; i < Books.Length; i++)
        {

            if (Books[i].author == authorsearch)
            {
                ReturnBooks[counter] = Books[i];
                counter++;
            }

        }

        for (int i = 0; i < ReturnBooks.Length; i++)
        {
            if (ReturnBooks[i] != null)
            {
                Console.WriteLine(ReturnBooks[i].name);
            }
        }

    }

    public void AfterYearBooks(Book[] Books)     //поиск книг,выпущенных после года
    {

        Console.WriteLine("Введите год: ");

        int yeartocompare = Convert.ToInt32(Console.ReadLine());

        Book[] ReturnBooks = new Book[Books.Length];

        int counter = 0;
        for (int i = 0; i < Books.Length; i++)
        {

            if (Books[i].year > yeartocompare)
            {
                ReturnBooks[counter] = Books[i];
                counter++;
            }
        }

        for (int i = 0; i < ReturnBooks.Length; i++)
        {
            if (ReturnBooks[i] != null)
            {
                Console.WriteLine(ReturnBooks[i].name);
            }
        } 
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        //////////////////////////////////////////////// 1

        string[] months = new string[] { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", 
                                         "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };


        int n = 6;


        var selectmonths = from p in months 
                           where p.Length == n 
                           select p;


        foreach(var elem in selectmonths)
        {
            Console.WriteLine(elem);
        }
        Console.WriteLine("-------------------------------------------");

        ///////////////////////////////////////////////// 2
        Book book1 = new Book(1, "book1", "author1", "publisher1",  2009, 120, 1200);
        Book book2 = new Book(2, "book2", "author2", "publisher2",  2017, 250, 2500);
        Book book3 = new Book(3, "book3", "author3", "publisher3",  2006, 300, 2600);
        Book book4 = new Book(4, "book4", "author4", "publisher4",  2004, 320, 2000);
        Book book5 = new Book(5, "book5", "author5", "publisher5",  2005, 180, 1300);
        Book book6 = new Book(1, "book6", "author6", "publisher6",  2009, 120, 1200);
        Book book7 = new Book(2, "book7", "author7", "publisher7",  2017, 115, 2500);
        Book book8 = new Book(3, "book8", "author8", "publisher8",  2006, 300, 800);
        Book book9 = new Book(4, "book9", "author9", "publisher9",  2004, 320, 2000);
        Book book10 = new Book(5,"book10","author10", "publisher10",2005, 180, 1300);


        List<Book> library = new List<Book>();


        library.Add(book1);
        library.Add(book2);
        library.Add(book3);
        library.Add(book4);
        library.Add(book5);
        library.Add(book6);
        library.Add(book7);
        library.Add(book8);
        library.Add(book9);
        library.Add(book10);



        var authoryear = from p in library
                               where p.author == "author1" 
                               where p.year == 2009
                           select p;


        foreach (Book elem in authoryear)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");



        var afteryear= from p in library
                               where p.year > 2008
                               select p;


        foreach (Book elem in afteryear)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");




        var minpages = from p in library
                             orderby p.pages
                             select p;

        var minpage = minpages.Take(1).ToList();
        Console.WriteLine("minimum pages");
        Console.WriteLine(minpage.Last().name);
        Console.WriteLine("\n-------------------------------------------");



        var maxpagesminprice = from p in library
                            orderby  p.pages descending, p.price   // сортировка по возрастанию по убыванию
                            select p;

        int counter = 0;
        foreach (Book elem in maxpagesminprice)
        {
            if (counter < 5)
            {
                Console.WriteLine("КНИГА - " + elem.name);
                Console.WriteLine("СТОИМОСТЬ - " + elem.price);
                Console.WriteLine("СТРАНИЦЫ - " + elem.pages);
            }
            else
            {
                break;
            }
            counter++;
        }
        Console.WriteLine("-------------------------------------------");


        var minprice = from p in library
                       orderby p.price
                       select p;


        foreach (Book elem in minprice)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("Книги с количеством страниц больше 190, отсортированные по цене:");
        //1
        var CustomQ = from p in library
                      orderby p.price
                      where p.pages > 190 
                      select p;


        foreach (Book elem in CustomQ)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");


        //2
        Console.WriteLine("Книги с количеством страниц меньше 190:");
        var CustomQ2 = library.Except(CustomQ);



        foreach (Book elem in CustomQ2)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");


        //3
        var CustomQ3 = CustomQ2.Count();

        //4
        var CustomQ4 = from p in library
                       group p by p.price;

        Console.WriteLine("Группировка книг по году публикации:");

        foreach (var company in CustomQ4)
        {
            Console.WriteLine(company.Key);

            foreach (var elem in company)
            {
                Console.WriteLine(elem.name);
            }
            Console.WriteLine(); 
        }
        Console.WriteLine("-------------------------------------------");


        Console.WriteLine("Количество книг, у которых меньше 190 страниц: " + CustomQ3);


        Console.WriteLine("-------------------------------------------");



        //5
        bool CustomQ5 = library.All(s => s.name.StartsWith("b"));

        Console.WriteLine("Правда ли, что все элементы библиотеки начинаются с \"b\": " + CustomQ5);

        Console.WriteLine("-------------------------------------------");


        var CustomQJoin = from p1 in CustomQ
                          join c in CustomQ2 on p1.price equals c.price
                          select c;

        foreach (Book elem in CustomQJoin)
        {
            Console.WriteLine(elem.name);
        }
        Console.WriteLine("-------------------------------------------");


        var CustomQ6 = from p in library
                       where p.pages > 190
                       where p.price < 120000
                       orderby p.price
                      
        select p;

        int amount = CustomQ6.Count();


    }




}