using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private ButtonController start;
    private ButtonController quit;

    // Use this for initialization
    void Start ()
    {
        quit = GameObject.Find("Quit").AddComponent<ButtonController>();
        start = GameObject.Find("Start").AddComponent<ButtonController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Button();
    }

    public void Button()
    {
        if (start.ButtonPressed)
        {
            StartGame();
        }
        if (quit.ButtonPressed)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
