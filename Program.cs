using System.Text.Json;
Console.WriteLine("Welcome to the game!");
Console.WriteLine("Do you want to continue your previous game? (y/n)");
string? continueChoice = Console.ReadLine();
    Player startGame()
    {
        switch (continueChoice)
        {

            case "y":
                return continueGame();
                
            case "n":
                return selectClass();
            default:
                Console.WriteLine("Invalid choice. Please enter 'y' or 'n'.");
                return startGame();
                
        }
    }
Player player = startGame();
Random variety = new Random();
int enemyHealth = variety.Next(50, 101);
int enemyAttackPower = variety.Next(10, 21);
Enemy enemy = new Enemy(enemyHealth, enemyAttackPower);


while (true)
{
    player.Attack(enemy);
    if (enemy.Health <= 0)
    {
        Console.WriteLine("Enemy defeated!");
        string savePlayer = JsonSerializer.Serialize(player);
        File.WriteAllText("playerData.json", savePlayer);
        break;
    }
    enemy.Attack(player);
    if (player.Health <= 0)
    {
        Console.WriteLine("Player defeated!");
        File.Delete("playerData.json");
        break;
    }
}
Player continueGame()
{
    if (File.Exists("playerData.json"))
    {
        string savedPlayer = File.ReadAllText("playerData.json");
        Player player = JsonSerializer.Deserialize<Player>(savedPlayer);
        Console.WriteLine($"Welcome back! Your health is {player.Health} and your attack power is {player.AttackPower}.");
        return player;
    }
    else
    {
        Console.WriteLine("No saved game found. Starting a new game.");
        return selectClass();
    }
}
Player selectClass()
{
    Console.WriteLine("Select your class: 1. Warrior 2. Mage");
    string? classChoice = Console.ReadLine();
    switch (classChoice)
    {
        case "1":
            Console.WriteLine("You have selected Warrior.");
            File.WriteAllText("playerClass.txt", "Warrior");
            return new Warrior();
        case "2":
            Console.WriteLine("You have selected Mage.");
            return new Mage();
        default:
            Console.WriteLine("Invalid choice. 1 for Warrior, 2 for Mage.");
            return selectClass();
    }
}
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
