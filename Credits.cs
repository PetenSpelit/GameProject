using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    private Text endtrigger;
    

    // Use this for initialization
    void Start ()
    {
        endtrigger = GameObject.Find("EndTrigger").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(0);
        }
    }

    
}
