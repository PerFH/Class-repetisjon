
public class Character : IAttack
{

    public int Health { get; set; }
    public int AttackPower { get; set; }
    public void Attack(Character target)
    {
        target.Health -= this.AttackPower;
        Console.WriteLine($"{target.GetType().Name} has {target.Health} health remaining.");
    }
}

public class Player : Character
{
    public Player()
    {
        Health = 100;
        AttackPower = 20;
    }
}

public class Warrior : Player
{
    public Warrior() : base()
    {
        Health += 50;
        AttackPower += 0;
    }
}

public class Mage : Player
{
    public Mage() : base()
    {
        Health -= 20;
        AttackPower -= 10;
    }
}
public class Enemy : Character
{
    public Enemy(int health, int attackPower)
    {
        Health = health;
        AttackPower = attackPower;
    }
}
public interface IAttack
{
    void Attack(Character target);
}
