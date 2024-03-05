using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public string[] dialogue;
    public Text wallet;
    public int coin;
    public int coinMax = 2;

    public Button NegotiatePay;

    public Button Play;

    public Text inkDialogue;
    public float salary = 0;

    // Start is called before the first frame update
    void Awake()
    {
        dialogue = new string[1];
    }

    private void Start()
    {
        dialogue[0] = "I'll pay you 100,000 Yen to catch this guy for me.";
        inkDialogue.text = dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        wallet.text = GameManager.instance.Wallet.ToString();
    }

    public void Deal()
    {
        GameManager.instance.Wallet += salary;
        SceneManager.LoadScene("Slums");
        GameManager.instance.questActive = true;
    }
    public void CoinFlip()
    {
        coin = Random.Range(0, coinMax);
        Negotiate(coin);
        Play.interactable = true;
    }

    void Negotiate(int c)
    {
        switch(c)
        {
            case 0:
                inkDialogue.text = "Are you serious? I can't do 500,000!";
                salary = 100000f;
                break;
            case 1:
                inkDialogue.text = "I mean, 500,000 is a lot. Why don't we say like 250,000?";
                salary = 250000;
                break;
            case 2:
                inkDialogue.text = "We've had a good year, you've earned it.";
                salary = 500000;
                break;
        }
    }
}
