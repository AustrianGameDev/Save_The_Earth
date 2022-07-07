using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Settings
{
    public float volume;

    public Settings()
    {
        volume = 1f;
    }

    public Settings(MainMenuButtons menuButtons)
    {
        volume = menuButtons.GetVolume();
    }
}
