using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeUI : MonoBehaviour
{
    public GameObject FirstToken;
    public GameObject SecondToken;
    public GameObject ThirdToken;

    public bool strike1;
    public bool strike2;
    public bool strike3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        strike1 = GameManager.instance.strikes[0];
        strike2 = GameManager.instance.strikes[1];
        strike3 = GameManager.instance.strikes[2];
        UpdateUI();
    }

    void UpdateUI()
    {
        if (strike1 == true)
        {
            FirstToken.SetActive(false);
        }
        if (strike2 == true)
        {
            SecondToken.SetActive(false);
        }
        if (strike3 == true)
        {
            ThirdToken.SetActive(false);
        }
    }
}
