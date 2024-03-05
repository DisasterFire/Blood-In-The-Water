using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform playerTf;

    public Text wallet;
    public GameObject sobriety;
    public string gamblingRoom;
    public string streets;
    public string bar;

    public float speed;
    public GameObject indicator;
    public GameObject BarIndicator;
    public GameObject DrinkingUI;

    public float jumpHeight = 5f;

    public GameObject walletTxt;

    public Image reputation;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().sleepMode = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        HorMove();
        //Jump();
        CheckWallet();
        //GameManager.instance.Soused();
        wallet.text = GameManager.instance.Wallet.ToString();
        reputation.fillAmount = GameManager.instance.RepValue;
        DebugStrike();
        Dash();
    }

    void HorMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = playerTf.right * speed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -playerTf.right * speed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Door")
        {
            Debug.Log("Gamble Now");
            indicator.SetActive(true);
        }
        if(other.tag == "BarDoorEnter")
        {
            BarIndicator.SetActive(true);
        }
        if(other.tag == "BarDoor")
        {
            indicator.SetActive(true);
        }
        if(other.tag == "Drinking")
        {
            Debug.Log("Wanna drink?");
            DrinkingUI.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            indicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene(gamblingRoom);
                GameManager.instance.gamble1 = true;
            }
        }

        if(other.tag == "BarDoorEnter")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene(bar);
                GameManager.instance.barDoor = true;
            }
        }

        if(other.tag == "BarDoor")
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene(streets);
                GameManager.instance.barDoor = true;
            }
        }

        if(other.tag == "Office")
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("OfficeBuilding");
            }
        }
        if(other.tag == "Car")
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("Slums");
            }
        }
        if (other.tag == "Car1")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("Sendatsu");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Okay, bitch");
            indicator.SetActive(false);
        }
        if (other.tag == "BarDoorEnter")
        {
            BarIndicator.SetActive(false);
        }
        if (other.tag == "BarDoor")
        {
            indicator.SetActive(false);
        }
        if (other.tag == "Drinking")
        {
            Debug.Log("Have a good night then.");
            DrinkingUI.SetActive(false);
        }
    }

    void CheckWallet()
    {
        if (Input.GetKey(KeyCode.C))
        {
            walletTxt.SetActive(true);
            sobriety.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            walletTxt.SetActive(false);
            sobriety.SetActive(false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void DebugStrike()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Error: Striking");
            GameManager.instance.AddStrike();
        }
    }
}
