using System;




public delegate void Action(Hero actionmember, ref Hero target);





public struct Hero
{
    public Hero(int _HealthPoints,int _AttackPoints, int _HealingPoints )
    {
        HealthPoints = _HealthPoints;

        AttackPoints = _AttackPoints;

        HealingPoints = _HealthPoints;
    }

    public int HealthPoints { get; set; }
    public int AttackPoints { get; set; }
    public int HealingPoints { get; set; }
}


public class AttackHealGame
{

    Action acting = new Action(Attack);

    public event Action ActionReport;


    
    static void Main(string[] args)
    {
        Hero Zeus = new Hero(700, 70, 0);
        Hero Luna = new Hero(850, 75, 30);
        Hero WD = new Hero(550, 20, 100);



    }



    public  void Attack(Hero h1, ref Hero h2)
    {
        h2.HealthPoints -= h1.AttackPoints;
    }

    private void Heal(Hero h1, ref Hero h2)
    {
        h2.HealthPoints += h1.HealingPoints;
    }

}



class Program
{ 

         
}



