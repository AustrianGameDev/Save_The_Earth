using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button bt_start;
    [SerializeField] private Button bt_options;
    [SerializeField] private Button bt_back;
    [SerializeField] private Button bt_quit;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject option;

    [SerializeField] private SceneAsset gameScene;
    
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
        //Debug.Log("Start");

        SceneManager.LoadScene(gameScene.name);
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
