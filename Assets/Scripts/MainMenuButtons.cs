using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private Slider sl_volume;
    //[SerializeField] private GameObject volumeVal;
    [SerializeField] private TextMeshProUGUI volumeVal;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject option;

    [SerializeField] private SceneAsset gameScene;

    [SerializeField] private AudioClip click;

    // ToDo: Save volume
    private float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        showVolume();
        
        bt_start.onClick.AddListener(start);
        bt_options.onClick.AddListener(options);
        bt_back.onClick.AddListener(back);
        bt_quit.onClick.AddListener(quit);
        
        sl_volume.onValueChanged.AddListener(changeVolume);
    }

    private void start()
    {
        playClick();

        StartCoroutine(loadGame());
    }

    private IEnumerator loadGame()
    {
        yield return new WaitForSeconds(0.2f);
        
        SceneManager.LoadScene(gameScene.name);
    }

    private void options()
    {
        playClick();
        
        main.SetActive(false);
        story.SetActive(false);
        option.SetActive(true);
    }

    private void back()
    {
        playClick();
        
        main.SetActive(true);
        story.SetActive(true);
        option.SetActive(false);
    }

    private void quit()
    {
        playClick();

        StartCoroutine(quitGame());
    }

    private static IEnumerator quitGame()
    {
        yield return new WaitForSeconds(0.2f);
        
        // ToDo: Quit game
    }
    
    private void changeVolume(float volume)
    {
        this.volume = volume;
        showVolume();
        //playClick(); // For Debug ;)
    }

    private void showVolume()
    {
        //volumeVal.GetComponent<TextMeshProUGUI>().SetText(volume.ToString());
        int volumeInt = (int)(volume * 100);
        volumeVal.SetText(volumeInt.ToString());
    }

    private void playClick()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, volume);
    }
}
