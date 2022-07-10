using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class Game
{
    public BigInteger score;
    
    public BigInteger click;
    public int clickLvl;
    
    public BigInteger perSecond;
    public int perSecondLvl;

    public Game()
    {
        score = 0;
        
        click = 1;
        clickLvl = 1;
        
        perSecond = 0;
        perSecondLvl = 1;
    }

    public Game(GameController gameController)
    {
        score = gameController.GetScore();
        
        click = gameController.GetClick();
        clickLvl = gameController.GetClickLvl();
        
        perSecond = gameController.GetPerSecond();
        perSecondLvl = gameController.GetPerSecondLvl();
    }
}
