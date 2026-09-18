public class Controller
{
Datasource datasource = new Datasource();
    public Player startGame()
    {
        switch (View.introMessage())
        {
            case "y":
                return continueGame();

            case "n":
                return selectClass();
            default:
                View.invalidMessage();

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
                View.winMessage();
                datasource.SavePlayer(player);
                break;
            }
            enemy.Attack(player);
            if (player.Health <= 0)
            {
                View.loseMessage();
                datasource.deletePlayerData();
                break;
            }
        }
    }
    Player continueGame()
    {
        if (datasource.fileExists)
        {
            Player player = datasource.LoadPlayer();
            View.continueMessage(player);
            doCombat(player, getEnemy());
            return player;
        }
        else
        {
            View.noSave();

            return selectClass();
        }
    }
    Player selectClass()
    {
        View.selectClass();
        string? classChoice = Console.ReadLine();
        switch (classChoice)
        {
            case "1":
                View.warriorSelect();
                return new Warrior();
            case "2":
                View.mageSelect();
                return new Mage();
            default:
                View.invalidClassOption();
                return selectClass();
        }
    }

    Enemy getEnemy()
    {
        Random variety = new Random();
        Enemy enemy = new Enemy(getEnemyHealth(), getEnemyAttackPower());
        int getEnemyHealth()
        {
        int enemyHealth = variety.Next(50, 101);
        return enemyHealth;
        }
        int getEnemyAttackPower()
        {
        int enemyAttackPower = variety.Next(10, 21);
        return enemyAttackPower;
        }
        return enemy;
    }
}
