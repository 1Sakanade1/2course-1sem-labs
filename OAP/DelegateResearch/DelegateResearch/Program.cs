using System;



    public struct Hero
    {
        public Hero(int _HealthPoints, int _AttackPoints, int _HealingPoints, string _Name)
        {
            HealthPoints = _HealthPoints;

            AttackPoints = _AttackPoints;

            HealingPoints = _HealthPoints;

            Name = _Name;

            MaxHealth = _HealthPoints;
        }

        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int HealingPoints { get; set; }

        public int MaxHealth { get; set; }

        public string Name { get; set; }
    }

namespace DelegateResearch
{

    public delegate void Action(Hero actionmember, ref Hero target);

    public delegate string StringChange(string str);



    class AttackHealGame
    {
        Action attack = new Action(Attack);
        Action heal = new Action(Heal);




        public Hero hero;





        static void Main(string[] args)
        {
            AttackHealGame a = new AttackHealGame();

            HeroDied += OnHeroDied;

            Hero Zeus = new Hero(700, 70, 0, "Zeus");
            Hero Galthran = new Hero(850, 750, 30, "Galthran");
            Hero Luna  = new Hero(550, 20, 100, "Luna");


            a.hero = new Hero(550, 20, 100, "WD");
            Console.WriteLine($"Стартовое здоровье героя {Zeus.Name} равно:{Zeus.HealthPoints}");
            Console.WriteLine("----------------------------------------------------");
            a.attack(Luna, ref Zeus);
            a.heal(Galthran, ref Zeus);


            Func<string, string> func = (str) => str.ToLower();
            Predicate<string> predicate = (str) => str.Length > 5;
            func += ChangeString.Lower;
            func += ChangeString.Upper;
            func += ChangeString.Remove;
            func += ChangeString.Add;
            func?.Invoke("Test");


        }


        public static void Attack(Hero h1, ref Hero h2)
        {
            h2.HealthPoints -= h1.AttackPoints;
            if (h2.HealthPoints < 0)
            {
                Console.WriteLine($"Герой {h1.Name} атакует героя {h2.Name}, нанося {h1.AttackPoints} урона");
                HeroDied?.Invoke();

                Console.WriteLine("----------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"Герой {h1.Name} атакует героя {h2.Name}, нанося {h1.AttackPoints} урона");

                Console.WriteLine($"Текущее здоровье героя {h2.Name}: {h2.HealthPoints}");

                Console.WriteLine("----------------------------------------------------");
            }
        }

        private static void Heal(Hero h1, ref Hero h2)
        {
            if (h2.HealthPoints + h1.HealingPoints >= h2.MaxHealth)
            {
                h2.HealthPoints = h2.MaxHealth;


                Console.WriteLine($"Герой {h1.Name} восстанавливает здоровье героя  {h2.Name} до максимума");

                Console.WriteLine($"Текущее здоровье героя {h2.Name}: {h2.HealthPoints}");

                Console.WriteLine("----------------------------------------------------");

            }
            else if (h2.HealthPoints == h2.MaxHealth)
            {
                Console.WriteLine($"вы не можете исцелить героя {h2.Name}, его здоровье максимальное");

                Console.WriteLine("----------------------------------------------------");
            }
            else
            {
                h2.HealthPoints += h1.HealingPoints;
                Console.WriteLine($"Герой {h1.Name} исцеляет героя {h2.Name}, восстанавливая {h1.AttackPoints} здоровья");

                Console.WriteLine($"Текущее здоровье героя {h2.Name}: {h2.HealthPoints}");

                Console.WriteLine("----------------------------------------------------");
            }
        }

        public delegate void ActionHandler();
        public static event ActionHandler HeroDied;

        public static void OnHeroDied()
        {
            Console.WriteLine("Герой погиб");
        }


    }



}

