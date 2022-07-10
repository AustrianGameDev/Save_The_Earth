using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTree : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private void OnMouseDown()
    {
        gameController.Click();
    }
}
