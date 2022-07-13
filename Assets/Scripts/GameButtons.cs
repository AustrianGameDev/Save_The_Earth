using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject notStatistics;
    [SerializeField] private GameObject statistics;
    
    [SerializeField] private Button bt_upgradeClick;
    [SerializeField] private Button bt_upgradePerSecond;
    [SerializeField] private Button bt_showStats;
    [SerializeField] private Button bt_backStats;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        
        bt_upgradeClick.onClick.AddListener(onUpgradeClick);
        bt_upgradePerSecond.onClick.AddListener(onUpgradePerSecond);
        bt_showStats.onClick.AddListener(onShowStats);
        bt_backStats.onClick.AddListener(onBackStats);
    }

    private void onUpgradeClick()
    {
        gameController.UpgradeClick();
    }

    private void onUpgradePerSecond()
    {
        gameController.UpgradePerSecond();
    }

    private void onShowStats()
    {
        notStatistics.SetActive(false);
        statistics.SetActive(true);
    }

    private void onBackStats()
    {
        notStatistics.SetActive(true);
        statistics.SetActive(false);
    }
}
