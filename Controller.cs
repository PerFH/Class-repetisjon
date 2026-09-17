public class Controller
{

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

    void doCombat(Player player, Enemy enemy)
    {


        while (true)
        {
            player.Attack(enemy);
            if (enemy.Health <= 0)
            {
                Console.WriteLine("Enemy defeated!");
                Datasource.SavePlayer(player);
                break;
            }
            enemy.Attack(player);
            if (player.Health <= 0)
            {
                Console.WriteLine("Player defeated!");
                Datasource.DeletePlayerData();
                break;
            }
        }
    }
    Player continueGame()
    {
        if (File.Exists("playerData.json"))
        {
            string savedPlayer = File.ReadAllText("playerData.json");
            Player player = Datasource.LoadPlayer();
            Console.WriteLine($"Welcome back! Your health is {player.Health} and your attack power is {player.AttackPower}.");
            doCombat(player, new Enemy(50, 10));
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
                return new Warrior();
            case "2":
                Console.WriteLine("You have selected Mage.");
                return new Mage();
            default:
                Console.WriteLine("Invalid choice. 1 for Warrior, 2 for Mage.");
                return selectClass();
        }
    }
        public int getEnemyHealth()
    {
        int enemyHealth = variety.Next(50, 101);
        return enemyHealth;
    }
    public int getEnemyAttackPower()
    {
        int enemyAttackPower = variety.Next(10, 21);
        return enemyAttackPower;
    }
}