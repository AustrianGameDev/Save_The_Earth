using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI perClickText;
    [SerializeField] private TextMeshProUGUI perSecondText;
    
    private BigInteger score;
    private BigInteger click;
    private BigInteger perSecond;
    
    // Start is called before the first frame update
    void Start()
    {
        // ToDo: Get from save
        score = 0;
        click = 1;
        perSecond = 0;
        
        updateScore();
        updatePerClick();
        updatePerSecond();
        
        InvokeRepeating(nameof(perSecondRepeat), 1f, 1f);
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

    // ToDo: Upgrade functions
    
    // Update Text
    private void updateScore()
    {
        scoreText.SetText(score.ToString());
    }

    private void updatePerClick()
    {
        perClickText.SetText(click.ToString());
    }

    private void updatePerSecond()
    {
        perSecondText.SetText(perSecond.ToString());
    }

    // Getters/Setters
    public BigInteger GetScore()
    {
        return score;
    }

    public BigInteger GetClick()
    {
        return click;
    }

    public void SetClick(BigInteger newValue)
    {
        click = newValue;
        updatePerClick();
    }

    public BigInteger GetPerSecond()
    {
        return perSecond;
    }

    public void SetPerSecond(BigInteger newValue)
    {
        perSecond = newValue;
        updatePerSecond();
    }
}
