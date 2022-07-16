using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ClickTree : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private int changeScale;
    
    [SerializeField] private AudioClip rustling1;
    [SerializeField] private AudioClip rustling2;
    [SerializeField] private AudioClip rustling3;
    
    private float volume = 1f;

    private void Start()
    {
        Settings settings = SaveSystem.LoadSettings();
        volume = settings.volume;
    }

    private void OnMouseDown()
    {
        gameController.Click();
        playRustling();
        transform.localScale += new Vector3(changeScale, changeScale, changeScale);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
    }

    private void playRustling()
    {
        Random rand = new Random();
        AudioClip clip = null;
        
        switch(rand.Next(3 - 1 + 1) + 1)
        {
            case 1:
                clip = rustling1;
                break;
            case 2:
                clip = rustling2;
                break;
            case 3:
                clip = rustling3;
                break;
        }
        
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }
}
