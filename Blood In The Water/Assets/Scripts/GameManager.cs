using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Wallet = 100000f;
    public static GameManager instance;
    public bool gamble1 = false;
    public bool barDoor = false;
    public bool barExit = false;
    public bool marked = false;
    public bool questActive = false;
    public float RepValue = 0f;
    public float Sobriety = 0f;

    public GameObject NPCSpawn;
    public GameObject Enemy;

    public float playerHealth = 10;
    public float sobriety = 0;
    public float strength = 5;

    public bool[] strikes = new bool[3];
    public int strikeNo = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null || gamble1 == true || barDoor == true || barExit == true)
        {
            if(instance.marked == false)
            {
                GameObject.Destroy(instance);
                return;
            }
            else
            {
                return;
            }
        }    
        else if(gamble1 == false || barDoor == false || barExit == false)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            marked = true;
        }

        for(int i = 0; i<3; i++)
        {
            strikes[i] = false;
        }
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCSpawn = GameObject.FindGameObjectWithTag("Spawn");

        if (questActive == true)
        {
            Instantiate(Enemy, NPCSpawn.transform);
            questActive = false;
        }



        if (strikes[0] == true && strikes[1] == true && strikes[2] == true)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Soused()
    {
        if(sobriety >= 1 && sobriety < 5)
        {
            //VisionBlur++
            //ControlDelay++
            //Charisma++
        }
        else if(sobriety >= 5 && sobriety < 10)
        {
            //VisionBlur += 5
            //ControlsDelay += 2
            //Charisma += 2
        }
        else if(sobriety >= 10)
        {
            //VisionBlur += 10
            //COntrolsDelay += 5
            //Charisma -= 10
        }
    }

    public void AddStrike()
    {
        GameManager.instance.strikes[strikeNo] = true;
        if (strikeNo < 2)
        {
            strikeNo++;
        }
    }
}
