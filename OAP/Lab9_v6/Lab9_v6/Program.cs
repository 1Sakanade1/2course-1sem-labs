using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab9_v6
{
    class Program
    {
        public class Computer
        {
            public string name { get; set; }
            public string version { get; set; }
            public string model { get; set; }
            public string developer { get; set; }

            public Computer(string _name, string _version, string _model, string _developer)
            {
                _name = name;
                _version = version;
                _model = model;
                _developer = developer;

            }

            public void computerinfo()
            {
                Console.WriteLine($"Компьютер:\nНазвание -{name}\nВерсия - {version}\nМодель - {model}\nРазработчик - {developer}");
            }
        }
           




        static void Main(string[] args)
        {
            HashSet<string> spisok = new HashSet<string>()
        {
            "Николай",
            "Дмитрий",
            "Валерий",
            "Сергей",
            "Сергей"
        };

            spisok.Add("Александр");
            spisok.Remove("Валерий");
            foreach (var item in spisok)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------------------------");
            Computer comp1 = new Computer("Lenovo", "JU716738QE", "Legion", "China");
            Computer comp2 = new Computer("Asus", "KJ837617NL", "ROG", "China");

            Stack<Computer> topology = new Stack<Computer>(2);
            topology.Push(comp1);
            topology.Push(comp2);
            topology.GiveHeadElement();
            Console.WriteLine("\n");
            topology.AllElementsOut();
            topology.ElementSearch(comp1);
            

            Console.WriteLine("---------------------------------------------------------------------------");

            Queue<string> people = new Queue<string>();

          foreach(var elem in spisok)
            {
                people.Enqueue(elem);

            }
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------------------------");
            static void IsQueueContain(Queue<string> ochered,string search)
            {
               
                bool key = ochered.Contains(search);
                if (key)
                {
                    Console.WriteLine(search);
                }
            }

            static void QueueOut(Queue<string> ochered)
            {
                foreach(var elem in ochered)
                {
                    Console.WriteLine(elem);
                }



            }

            IsQueueContain(people, "Николай");
            Console.WriteLine();
            QueueOut(people);

            Console.WriteLine("---------------------------------------------------------------------------");

            ObservableCollection<Computer> obscoll = new ObservableCollection<Computer>()
            {
                new Computer("Lenovo", "JU716738QE", "Legion", "China"),
                new Computer("Asus", "KJ837617NL", "ROG", "China")
            };

            obscoll.CollectionChanged += ObservableMethods.MyCollectionChanged;

            obscoll.Add(new Computer("Lenovo", "JU742428QE", "Legion", "USA"));


        }
    }


    public class ObservableMethods
    {
        public static void MyCollectionChanged(object? sender,NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Console.WriteLine("Добавлен элемент");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Console.WriteLine("Удален элемент");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Console.WriteLine("Замена элемента");
                    break;
            }
        }

    }


}
