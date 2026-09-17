
public class Program
{
    public static void Main(string[] args)
    {
        //View.introMessage();
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Do you want to continue your previous game? (y/n)");
        public string? continueChoice = Console.ReadLine();

        Player player = Controller.startGame();
        Random variety = new Random();


        Enemy enemy = new Enemy(getEnemyHealth(), getEnemyAttackPower());

    }
}