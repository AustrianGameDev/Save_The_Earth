using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string settingsPath = Application.persistentDataPath + "/settings.ste";
    
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
}
