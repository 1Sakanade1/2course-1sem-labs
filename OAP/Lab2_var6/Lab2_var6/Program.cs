using System;


public partial class  Book
{
    private static readonly string language;  // поле только для чтения (присвоение значения полю может происходить только при объявлении или в конструкторе этого класса.)
    private static  int id { get; set; }         
    private string name { get; set; }
    private string author { get; set; }
    private string publisher { get; set; }
    private int Year = 1;
    static private int amount = 0;
    private int year
    {
        set
        {
            if (value < 0 || value > 2022)
                Console.WriteLine("неверно указан год");
            else Year = value;
        }
        get { return Year; }
    }
    private int pages;
    private bool pereplet;

 /*   public Book()
    {
        name = "unnamed book";
        author = "unknown";
        publisher = "unknown";
    }
*/
    public Book(int i, string na, string au,int yr)
    {
        amount++;
        id = i;
        name = na;
        author = au;
        publisher = "unknown";
        year = yr;
        
    }

    public Book(int i, string na, string au,int yr, string pub = "unknown")
    {
        amount++;
        id = i;
        name = na;
        author = au;
        publisher = pub;
        year = yr;

    }

    static Book()
    {
        language = "unknown";

        amount = amount++;
    }


    private Book() { }

    static void GiveShortInfo(Book a)
    {
        Console.WriteLine("Название" + a.name);
        Console.WriteLine("Автор"+ a.author);
        Console.WriteLine("Издатель"+ a.publisher);

    }

    public int ChangeYear ( ref Book book)
    {

        Console.WriteLine("Введите год написания книги");
        book.year =Convert.ToInt32( Console.ReadLine());
        return id;
    }

    public void DeleteBook (out string name)
    {

        name = "deleted_book";

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


    public class massivesofbooks
    {

      Book[] massiv;
        public void AuthorsBooks()
        {

            Console.WriteLine("Поиск по автору: ");

            string authorsearch = Console.ReadLine();

            Book[] ReturnBooks = new Book[massiv.Length];

            int counter = 0;
            for (int i = 0; i < massiv.Length; i++)
            {

                if (Convert.ToBoolean(massiv[i].author = authorsearch))
                {
                    ReturnBooks[counter] = massiv[i];
                }
            }

            for (int i = 0; i < ReturnBooks.Length; i++)
            {
                Console.WriteLine(ReturnBooks[i]);
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


        //zxcqwe

    }
}
    




namespace Lab2_var6
{
    class Program
    {

        static void Main(string[] args)
        {

            //   Book b = new Book();   // если разкоментировать, то выдаст ошибку о невозможности создать экземпляр класса из-за уровня защиты конструктора
            Book b = new Book(1,"sz","zx",2009);

            Book a = new Book(1,"book1","author1",2017, "publisher1");
            Book c = new Book(2, "book2", "author1",2006, "publisher2");
            Book d = new Book(3, "book3", "author3",2004);
            d.ChangeYear(ref a); 

            Console.WriteLine(d.Equals(c));

            Console.WriteLine(d.GetType());

            Book[] library = new Book[3] {a,c,d};
            var zxc = new { id = 1,name = "var_book",author = "var_auth",publisher = "var pub" };
            Console.WriteLine(zxc.name);


            
            

            

        }
    }
}
