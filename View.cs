public class View
{
    public static void introMessage()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Do you want to continue your previous game? (y/n)");
        Controller.startGame();
    }
}