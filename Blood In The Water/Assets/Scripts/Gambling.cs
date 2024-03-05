using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink;
using Unity.VisualScripting;
using System.Data;

public class Gambling : MonoBehaviour
{
    public Text wallet;
    public Image enemyHealth;
    public Button Punch;
    public Button Play;
    public Button Bet;
    public float bet = 0f;
    public GameObject enemyHolder;
    public int coinMax = 2;

    public int punchInt = 0;
    public Text inkDialogue;
   // public InkFile GamblingDialogue;

    public string[] dialogue;

    public string Sendatsu;

    public int coin;

    private void Awake()
    {
        GameManager.instance.gamble1 = true;

        dialogue = new string[8];
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue[0] = "Alright, ready to lose your money?";
        dialogue[1] = "Ouch, hey! Not cool.";
        dialogue[2] = "Ugh...my head hurts";
        dialogue[3] = "Alright, that's it.";
        dialogue[4] = "Stop it...please.";
        dialogue[5] = "You...";
        dialogue[6] = "...";
        dialogue[7] = "you..bastard";

        inkDialogue.text = dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        wallet.text = GameManager.instance.Wallet.ToString();
    }

    public void BetMoney()
    {
        GameManager.instance.Wallet -= 1000f;
        bet += 1000f;
        Play.interactable = true;
    }

    public void PunchEnemy()
    {
        EnemyUnit.instance.HPValue -= 0.15f;
        enemyHealth.fillAmount -= 0.15f;
        if(EnemyUnit.instance.HPValue <= 0)
        {
            Punch.interactable = false;
            enemyHolder.SetActive(false);
            GameManager.instance.Wallet += 50000;
            SceneManager.LoadScene(Sendatsu);
            GameManager.instance.RepValue += 0.25f;
        }
        coinMax += 1;

        if (punchInt < 7)
        {
            punchInt++;
        }
        else if(punchInt >= 7)
        {
             inkDialogue.text = dialogue[7];
        }

        inkDialogue.text = dialogue[punchInt];

    }

    public void CoinFlip()
    {
        coin = Random.Range(0, coinMax);
        Gamble(coin);
    }

    void Gamble(int cCoin)
    {
        switch(cCoin)
        {
            case 0:
                GameManager.instance.Wallet -= bet;
                Debug.Log("Lose");
                inkDialogue.text = "Haha. Thanks for the money, chump.";
                break;
            case 1:
                bet *= 2;
                GameManager.instance.Wallet += bet;
                Debug.Log("Win");
                inkDialogue.text = "Dammit";
                break;
            case 2:
                GameManager.instance.Wallet -= bet*2;
                Debug.Log("Medium Lose");
                inkDialogue.text = "How does it feel to lose all that?";
                break;
            case 3:
                bet *= 3;
                GameManager.instance.Wallet += bet*2;
                Debug.Log("Medium Win");
                inkDialogue.text = "Dammit. YOu must have cheated!";
                break;
            case 4:
                GameManager.instance.Wallet -= bet*3;
                Debug.Log("Hard Lose");
                inkDialogue.text = "I'm taking all your fucking money.";
                break;
            case 5:
                bet *= 5;
                GameManager.instance.Wallet += bet * 3;
                Debug.Log("Hard Win");
                inkDialogue.text = "FUCK!";
                break;
            case 6:
                GameManager.instance.Wallet -= bet * 4;
                Debug.Log("Super Lose");
                inkDialogue.text = "Such a loser.";
                break;
            case 7:
                GameManager.instance.Wallet -= bet * 5;
                Debug.Log("Extreme Loss");
                inkDialogue.text = "I'm eating good tonight.";
                break;
            case 8:
                GameManager.instance.Wallet -= bet * 10;
                Debug.Log("You've lost money");
                inkDialogue.text = "I'M RICH!";
                break;
        }
        bet = 0;
        Play.interactable = false;
        if(GameManager.instance.Wallet <= 0)
        {
            GameManager.instance.Wallet = 0;
            Bet.interactable = false;
        }
    }
}
