using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class Game
{
    public BigInteger score;
    public BigInteger click;
    public BigInteger perSecond;

    public Game()
    {
        score = 0;
        click = 1;
        perSecond = 0;
    }

    public Game(GameController gameController)
    {
        score = gameController.GetScore();
        click = gameController.GetClick();
        perSecond = gameController.GetPerSecond();
    }
}
