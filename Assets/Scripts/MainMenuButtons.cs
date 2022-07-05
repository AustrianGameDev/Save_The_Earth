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
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject option;

    [SerializeField] private SceneAsset gameScene;

    [SerializeField] private AudioClip click;
    
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
        AudioSource.PlayClipAtPoint(click, transform.position, 1f);

        StartCoroutine(loadGame());
    }

    private IEnumerator loadGame()
    {
        yield return new WaitForSeconds(0.2f);
        
        SceneManager.LoadScene(gameScene.name);
    }

    private void options()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 1f);
        
        main.SetActive(false);
        story.SetActive(false);
        option.SetActive(true);
    }

    private void back()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 1f);
        
        main.SetActive(true);
        story.SetActive(true);
        option.SetActive(false);
    }

    private void quit()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 1f);

        StartCoroutine(quitGame());
    }

    private static IEnumerator quitGame()
    {
        yield return new WaitForSeconds(0.2f);
        
        // ToDo
    }
}
