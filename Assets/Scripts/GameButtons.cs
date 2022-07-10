using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private Button bt_upgradeClick;
    [SerializeField] private Button bt_upgradePerSecond;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        
        bt_upgradeClick.onClick.AddListener(onUpgradeClick);
        bt_upgradePerSecond.onClick.AddListener(onUpgradePerSecond);
    }

    private void onUpgradeClick()
    {
        gameController.UpgradeClick();
    }

    private void onUpgradePerSecond()
    {
        gameController.UpgradePerSecond();
    }
}
