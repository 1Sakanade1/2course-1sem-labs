using System.Collections.Specialized;
using System.Linq.Expressions;

public class BackPack
{
   public  Dictionary<string, Tovar> Goods = new Dictionary<string, Tovar>();

   public int totalweight = 0;



    public struct Tovar
    {
       public int weight { get; set; }
       public int price { get; set; }
       public int amount { get; set; }

    }

    public void BackPackWork(int N)
    {
        bool key = true;
        while (key)
        {


            Console.WriteLine("Выберите действие:1 - добавить элемент в рюкзак  2 - убрать вещь из рюкзака 3 - рассчитать стоимость");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("введите название товара");
                    string _name = Console.ReadLine();

                    if (Goods.ContainsKey(_name))
                    {
                        Console.WriteLine("этот товар уже добавлен, выберите другой");
                        break;
                    }

                    Console.WriteLine("введите вес товара");
                    int _weight = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("введите стоимость товара");
                    int _price = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("введите количество товара");
                    int _amount = Convert.ToInt32(Console.ReadLine());

                    totalweight += _weight*_amount;

                    if (totalweight > N)
                    {
                        Console.WriteLine("В рюкзак столько не влезет!");
                    }
                    else
                    {
                        Tovar tovartoadd = new Tovar();
                        tovartoadd.weight = _weight;
                        tovartoadd.price = _price;
                        tovartoadd.amount = _amount;
                        Goods.Add(_name, tovartoadd);






                        foreach (var elem in Goods)
                        {
                            Console.WriteLine(Goods.Keys);
                        }

                    }
                    break;

                case "2":
                    Console.WriteLine("введите имя товара,который вы хотите удалить: ");
                    string nametoremove = Console.ReadLine();

                    bool isdeletedkey = false;

                    foreach (var elem in Goods)
                    {
                        Tovar tovartoremove = elem.Value;
                        
                        if(elem.Key == nametoremove)
                        {
                            totalweight = totalweight - tovartoremove.weight * tovartoremove.amount;

                            Goods.Remove(nametoremove);
                            isdeletedkey= true;
                            break;
                        }
                    }

                    if (isdeletedkey)
                    {
                        Console.WriteLine("товар успешно удален");
                    }
                    else
                    {
                        Console.WriteLine("не удалось удалить товар");
                    }


                    break;
                case"3":

                    Console.WriteLine("список товаров:");
                    foreach(var elem in Goods)
                    {
                        Tovar tovarout = elem.Value;

                        Console.WriteLine("---------------------");

                        Console.WriteLine("Товар: " + elem.Key);
                        Console.WriteLine("Количество: " + tovarout.amount);
                        Console.WriteLine("Стоимость: " + tovarout.price);
                        Console.WriteLine("Масса: " + tovarout.weight);
                    }
                    Console.WriteLine("---------------------");
                    Console.WriteLine("итоговый вес: "+ totalweight);


                    break;





            }



        }



    }





}










class Program
{
    static void Main(string[] args)
    {
        int N = 10;

        BackPack a = new BackPack();
        a.BackPackWork(N);
    }
}