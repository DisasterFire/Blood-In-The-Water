using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoanEvasion : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Caught");
            collision.gameObject.SetActive(false);
            GameManager.instance.RepValue += 0.5f;
        }
    }
}
