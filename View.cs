public class View
{
    public static string introMessage()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Do you want to continue your previous game? (y/n)");
        string? continueChoice = Console.ReadLine();
        return continueChoice;
    }
    public static void continueMessage(Player player)
    {
        Console.WriteLine($"Welcome back! Your health is {player.Health} and your attack power is {player.AttackPower}.");
    }
    public static void invalidMessage()
    {
        Console.WriteLine("Invalid choice. Please enter 'y' or 'n'.");
    }
    public static void winMessage()
    {
        Console.WriteLine("Enemy defeated!");
    }
    public static void loseMessage()
    {
        Console.WriteLine("Player defeated!");   
    }
    public static void noSave()
    {
        Console.WriteLine("No saved game found. Starting a new game.");
    }
    public static void selectClass()
    {
        Console.WriteLine("Select your class: 1. Warrior 2. Mage");
    }
    public static void warriorSelect()
    {
        Console.WriteLine("You have selected Warrior.");
    }

    public static void mageSelect()
    {
        Console.WriteLine("You have selected Mage.");
    }

    public static void invalidClassOption()
    {
        Console.WriteLine("Invalid choice. 1 for Warrior, 2 for Mage.");
    }
}

