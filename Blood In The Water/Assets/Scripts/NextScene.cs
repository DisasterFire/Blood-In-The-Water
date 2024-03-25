using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Next());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(23.5f);
        Debug.Log("NextScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
