using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drinking : MonoBehaviour
{
    public Image soberMeter;
    public Button Beer;
    public Button Liquor;
    public Button Vodka;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrinkBeer()
    {
        if(GameManager.instance.Wallet >= 0)
        {
            GameManager.instance.sobriety += 1;
            GameManager.instance.Wallet -= 400;
            soberMeter.fillAmount += 0.1f;
        }
        else
        {
            GameManager.instance.Wallet = 0;
            Beer.interactable = false;
        }
    }

    public void DrinkLiquor()
    {
        if (GameManager.instance.Wallet >= 0)
        {
            GameManager.instance.sobriety += 5;
            GameManager.instance.Wallet -= 1000;
            soberMeter.fillAmount += 0.35f;
        }
        else
        {
            GameManager.instance.Wallet = 0;
            Liquor.interactable = false;
        }
    }

    public void DrinkVodka()
    {
        if (GameManager.instance.Wallet >= 0)
        {
            GameManager.instance.sobriety += 10;
            GameManager.instance.Wallet -= 1500;
            soberMeter.fillAmount += 0.5f;
        }
        else
        {
            GameManager.instance.Wallet = 0;
            Vodka.interactable = false;
        }
    }
}
