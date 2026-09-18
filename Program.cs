
public class Program
{
    public static void Main(string[] args)
    {
        Controller controller = new Controller();
        View.introMessage();
        controller.startGame();
    }
}