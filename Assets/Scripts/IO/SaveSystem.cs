using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string settingsPath = Application.persistentDataPath + "/settings.ste";
    private static readonly string gamePath = Application.persistentDataPath + "/game.ste";
    
    public static void SaveSettings(MainMenuButtons menuButtons)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(settingsPath, FileMode.Create);

        Settings settings = new Settings(menuButtons);
        
        formatter.Serialize(stream, settings);
        stream.Close();
    }

    public static Settings LoadSettings()
    {
        if(File.Exists(settingsPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(settingsPath, FileMode.Open);

            Settings settings = formatter.Deserialize(stream) as Settings;
            stream.Close();
            return settings;
        }
        else
        {
            Debug.Log("Settings file not found at " + settingsPath);
            return new Settings();
        }
    }

    public static void SaveGame(GameController gameController)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(gamePath, FileMode.Create);

        Game game = new Game(gameController);
        
        formatter.Serialize(stream, game);
        stream.Close();
    }

    public static Game LoadGame()
    {
        if(File.Exists(gamePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(gamePath, FileMode.Open);

            Game game = formatter.Deserialize(stream) as Game;
            stream.Close();
            return game;
        }
        else
        {
            Debug.Log("Game file not found at " + settingsPath);
            return new Game();
        }
    }
}
