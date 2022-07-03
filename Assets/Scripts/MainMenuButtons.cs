using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button bt_start;
    public Button bt_options;
    public Button bt_back;
    public Button bt_quit;

    public GameObject main;
    public GameObject option;
    
    // Start is called before the first frame update
    void Start()
    {
        bt_start.onClick.AddListener(start);
        bt_options.onClick.AddListener(options);
        bt_back.onClick.AddListener(back);
        bt_quit.onClick.AddListener(quit);
    }

    private void start()
    {
        Debug.Log("Start");
    }

    private void options()
    {
        //Debug.Log("Options");
        
        main.SetActive(false);
        option.SetActive(true);
    }

    private void back()
    {
        //Debug.Log("Back");
        
        main.SetActive(true);
        option.SetActive(false);
    }

    private void quit()
    {
        Debug.Log("Quit");
    }
}
