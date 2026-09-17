using System.Text.Json;
public class Program
{
    public static void Main(string[] args)
    {
        //View.introMessage();
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Do you want to continue your previous game? (y/n)");
        string? continueChoice = Console.ReadLine();

        Player player = startGame();
        Random variety = new Random();
        int enemyHealth = variety.Next(50, 101);
        int enemyAttackPower = variety.Next(10, 21);
        Enemy enemy = new Enemy(enemyHealth, enemyAttackPower);


    }
}