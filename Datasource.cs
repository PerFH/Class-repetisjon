using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
public class Datasource
{
    public bool fileExists
    {
        get
        {
            return File.Exists(getFile());
        }
    }
    private string getFile()
    {
        return "playerData.json";
    }
    public void SavePlayer(Player player)
    {
        string savePlayer = JsonSerializer.Serialize(player);
        File.WriteAllText(getFile(), savePlayer);
    }

    public Player LoadPlayer()
    {
        if (fileExists)
        { 
            string savedPlayer = File.ReadAllText(getFile());
            Player player = JsonSerializer.Deserialize<Player>(savedPlayer);
            return player;
        }
        else
        {
            return null;
        }
    }

    public void deletePlayerData()
    {
            File.Delete(getFile());
    }
}
