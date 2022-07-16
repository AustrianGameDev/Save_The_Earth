using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject notStatistics;
    [SerializeField] private GameObject statistics;
    
    [SerializeField] private Button bt_upgradeClick;
    [SerializeField] private Button bt_upgradePerSecond;
    [SerializeField] private Button bt_showStats;
    [SerializeField] private Button bt_backStats;
    [SerializeField] private Button bt_saveAndQuit;

    [SerializeField] private SceneAsset mainScene;
    
    [SerializeField] private AudioClip click;

    private GameController gameController;
    private float volume = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        
        Settings settings = SaveSystem.LoadSettings();
        volume = settings.volume;
        
        bt_upgradeClick.onClick.AddListener(onUpgradeClick);
        bt_upgradePerSecond.onClick.AddListener(onUpgradePerSecond);
        bt_showStats.onClick.AddListener(onShowStats);
        bt_backStats.onClick.AddListener(onBackStats);
        bt_saveAndQuit.onClick.AddListener(onSaveAndQuit);
    }

    private void onUpgradeClick()
    {
        gameController.UpgradeClick();
        playClick();
    }

    private void onUpgradePerSecond()
    {
        gameController.UpgradePerSecond();
        playClick();
    }

    private void onShowStats()
    {
        notStatistics.SetActive(false);
        statistics.SetActive(true);
        playClick();
    }

    private void onBackStats()
    {
        notStatistics.SetActive(true);
        statistics.SetActive(false);
        playClick();
    }

    private void onSaveAndQuit()
    {
        playClick();
        StartCoroutine(doSaveAndQuit());
    }

    private IEnumerator doSaveAndQuit()
    {
        yield return new WaitForSeconds(0.2f);
        
        SaveSystem.SaveGame(gameController);
        SceneManager.LoadScene(mainScene.name);
    }
    
    private void playClick()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, volume);
    }
}
