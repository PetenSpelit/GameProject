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
    /// <summary>
    /// Method for the buttons.
    /// </summary>
    public void Button()
    {
        if (start.ButtonPressed)
        {
            StartCoroutine(Delay(2));
        }
        if (quit.ButtonPressed)
        {
            EndGame();
        }
    }
    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void EndGame()
    {
        Application.Quit();
    }
    IEnumerator Delay(float sec)
    {
        yield return new WaitForSeconds(sec);
        StartGame();
    }
}
