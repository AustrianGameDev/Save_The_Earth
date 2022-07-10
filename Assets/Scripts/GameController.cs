using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private TextMeshProUGUI perClickText;
    [SerializeField] private TextMeshProUGUI perClickCost;

    [SerializeField] private TextMeshProUGUI perSecondText;
    [SerializeField] private TextMeshProUGUI perSecondCost;
    
    private BigInteger score;
    
    private BigInteger click;
    private int clickLvl;
    
    private BigInteger perSecond;
    private int perSecondLvl;
    
    // Start is called before the first frame update
    void Start()
    {
        // ToDo: Get from save
        score = 0;
        
        click = 1;
        clickLvl = 1;
        
        perSecond = 0;
        perSecondLvl = 1;
        
        updateText();
        
        InvokeRepeating(nameof(perSecondRepeat), 1f, 1f);
    }

    private void updateText()
    {
        updateScore();
        
        updatePerClick();
        updateClickCost();
        
        updatePerSecond();
        updatePerSecondCost();
    }
    
    // Basic functions
    public void Click()
    {
        score += click;
        updateScore();
    }

    private void perSecondRepeat()
    {
        score += perSecond;
        updateScore();
    }

    // Upgrade functions
    public void UpgradeClick()
    {
        BigInteger cost = getCostByLvl(clickLvl);
        
        if(cost > score)
        {
            return;
        }

        click += clickAmount();
        score -= cost;
        clickLvl++;
        
        updateScore();
        updatePerClick();
        updateClickCost();
    }

    private BigInteger clickAmount()
    {
        switch(clickLvl)
        {
            case 1: return 1;
            case 2: return 3;
            case 3: return 5;
            case 4: return 10;
            case 5: return 50;
            case 6: return 300;
            case 7: return 1500;
            case 8: return 4500;
            case 9: return 9000;
            default: return click / 10;
        }
    }

    public void UpgradePerSecond()
    {
        BigInteger cost = getCostByLvl(perSecondLvl);
        
        if(cost > score)
        {
            return;
        }

        perSecond += perSecondAmount();
        score -= cost;
        perSecondLvl++;
        
        updateScore();
        updatePerSecond();
        updatePerSecondCost();
    }
    
    private BigInteger perSecondAmount()
    {
        switch(clickLvl)
        {
            case 1: return 1;
            case 2: return 3;
            case 3: return 5;
            case 4: return 8;
            case 5: return 40;
            case 6: return 250;
            case 7: return 1000;
            case 8: return 3000;
            case 9: return 7500;
            default: return perSecond / 10;
        }
    }

    private BigInteger getCostByLvl(int lvl)
    {
        switch(lvl)
        {
            case 1: return 10;
            case 2: return 100;
            case 3: return 300;
            case 4: return 1000;
            case 5: return 15_000;
            case 6: return 35_000;
            case 7: return 70_000;
            case 8: return 150_000;
            case 9: return 500_000;
            default: return getCostByLvl(9) * lvl;
        }
    }

    private BigInteger getAmountByLvl(int lvl)
    {
        return 0;
    }
    
    // Update Text
    private void updateScore()
    {
        scoreText.SetText(thousandSeperators(score));
    }

    private void updatePerClick()
    {
        perClickText.SetText(thousandSeperators(click));
    }

    private void updateClickCost()
    {
        BigInteger cost = getCostByLvl(clickLvl);
        perClickCost.SetText("Cost:\n" + thousandSeperators(cost));
    }

    private void updatePerSecond()
    {
        perSecondText.SetText(thousandSeperators(perSecond));
    }

    private void updatePerSecondCost()
    {
        BigInteger cost = getCostByLvl(perSecondLvl);
        perSecondCost.SetText("Cost:\n" + thousandSeperators(cost));
    }

    // Getters
    public BigInteger GetScore()
    {
        return score;
    }

    public BigInteger GetClick()
    {
        return click;
    }

    public int GetClickLvl()
    {
        return clickLvl;
    }

    public BigInteger GetPerSecond()
    {
        return perSecond;
    }

    public int GetPerSecondLvl()
    {
        return perSecondLvl;
    }
    
    // Utils
    private string thousandSeperators(BigInteger number)
    {
        NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        nfi.NumberGroupSeparator = ".";
        return number.ToString("#,0", nfi);
    }
}
