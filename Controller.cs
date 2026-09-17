Public class Controller
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
                    return new Warrior();
                case "2":
                    Console.WriteLine("You have selected Mage.");
                    return new Mage();
                default:
                    Console.WriteLine("Invalid choice. 1 for Warrior, 2 for Mage.");
                    return selectClass();
            }
        }

}