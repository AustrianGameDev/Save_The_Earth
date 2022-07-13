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
    [SerializeField] private Button bt_reset;
    [SerializeField] private Button bt_cancelReset;
    [SerializeField] private Button bt_doReset;
    [SerializeField] private Button bt_quit;

    [SerializeField] private Slider sl_volume;
    //[SerializeField] private GameObject volumeVal;
    [SerializeField] private TextMeshProUGUI volumeVal;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject story;
    [SerializeField] private GameObject option;
    [SerializeField] private GameObject accept;

    [SerializeField] private SceneAsset gameScene;

    [SerializeField] private AudioClip click;

    private float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        loadSettings();
        
        showVolume();
        
        bt_start.onClick.AddListener(start);
        bt_options.onClick.AddListener(options);
        bt_back.onClick.AddListener(back);
        bt_reset.onClick.AddListener(reset);
        bt_cancelReset.onClick.AddListener(cancelReset);
        bt_doReset.onClick.AddListener(doReset);
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
        
        saveSettings();
        
        main.SetActive(true);
        story.SetActive(true);
        option.SetActive(false);
        accept.SetActive(false);
    }

    private void reset()
    {
        option.SetActive(false);
        accept.SetActive(true);
        playClick();
    }

    private void cancelReset()
    {
        option.SetActive(true);
        accept.SetActive(false);
        playClick();
    }

    private void doReset()
    {
        SaveSystem.ResetGame();
        back();
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

    private void loadSettings()
    {
        Settings settings = SaveSystem.LoadSettings();
        volume = settings.volume;
        sl_volume.value = volume;
    }

    private void saveSettings()
    {
        SaveSystem.SaveSettings(this);
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

    public float GetVolume()
    {
        return volume;
    }
}
