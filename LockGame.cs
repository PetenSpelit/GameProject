using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LockGame : MonoBehaviour {

    private GameObject lock1;
    private GameObject lock2;
    private GameObject lock3;
    private Button TopRight;
    private Button TopLeft;
    private Button MidRight;
    private Button MidLeft;
    private Button BottomRight;
    private Button BottomLeft;
    private Text Timer;
    private Button Timesup;
    private float starttime;
    private bool wait;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start() {
        //Game objects are being configured
        TopRight = GameObject.Find("TopRight").GetComponent<Button>(); 
        TopLeft = GameObject.Find("TopLeft").GetComponent<Button>();
        MidRight = GameObject.Find("MidRight").GetComponent<Button>();
        MidLeft = GameObject.Find("MidLeft").GetComponent<Button>();
        BottomRight = GameObject.Find("BottomRight").GetComponent<Button>();
        BottomLeft = GameObject.Find("BottomLeft").GetComponent<Button>();
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        Timesup = GameObject.Find("RestartGame").GetComponent<Button>();
        lock1 = GameObject.Find("LockNew1");
        lock2 = GameObject.Find("LockNew2");
        lock3 = GameObject.Find("LockNew3");
        //Listeners check if buttons are pressed
        TopRight.onClick.AddListener(() => ButtonPressed(TopRight)); 
        TopLeft.onClick.AddListener(() => ButtonPressed(TopLeft));
        MidRight.onClick.AddListener(() => ButtonPressed(MidRight));
        MidLeft.onClick.AddListener(() => ButtonPressed(MidLeft));
        BottomRight.onClick.AddListener(() => ButtonPressed(BottomRight));
        BottomLeft.onClick.AddListener(() => ButtonPressed(BottomLeft));
        Timesup.onClick.AddListener(() => ButtonPressed(Timesup));
        //Sets time for timer
        starttime = 10f;    
        wait = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Decreases one second from timer every second.
        starttime -= Time.deltaTime;
        //Changes timers text accordingly
        Timer.text = "Time left " + Mathf.Round(starttime); 
        Time.timeScale = 0;
        //Checks if this method needs to be called
        RestartScene(starttime); 
        
    }
    /// <summary>
    /// Restart checks if timer value is 0, it sets Timesup button active.
    /// </summary>
    /// <param name="starttime"></param>
    public void RestartScene(float starttime)
    {
        if (starttime <= 0)
        {
            Timesup.gameObject.SetActive(true);
            TopRight.enabled = !TopRight.enabled;
            TopLeft.enabled = !TopLeft.enabled;
            MidRight.enabled = !MidRight.enabled;
            MidLeft.enabled = !MidLeft.enabled;
            BottomRight.enabled = !BottomRight.enabled;
            BottomLeft.enabled = !BottomLeft.enabled;
        }
        //this method doesn't work without else. Bool wait is still kept false if Timesup button object isn't set active
        else
        {
            Timesup.gameObject.SetActive(false);
            Time.timeScale = 1;
            wait = false;
        }
    }
    /// <summary>
    /// This method checks which button is being pressed and it gives instructions to Unity how to move the game object.
    /// </summary>
    /// <param name="butt"></param>
    public void ButtonPressed(Button butt)
    {
        //rotates locks 1 & 2 at the same time
        if (butt == TopRight) 
        {
            lock1.transform.Rotate(Vector3.back * 15);
            lock2.transform.Rotate(Vector3.forward * 15);
        }
        if (butt == TopLeft)
        {
            lock1.transform.Rotate(Vector3.forward * 15);
        }
        if (butt == MidRight)
        {
            lock2.transform.Rotate(Vector3.back * 15);
        }
        //rotates locks 2 & 3 at the same time
        if (butt == MidLeft) 
        {
            lock2.transform.Rotate(Vector3.forward * 15);
            lock3.transform.Rotate(Vector3.forward * 15);
        }
        //rotates locks 3 & 1 at the same time
        if (butt == BottomRight) 
        {
            lock3.transform.Rotate(Vector3.back * 15);
            lock1.transform.Rotate(Vector3.forward * 15);
        }
        if (butt == BottomLeft)
        {
            lock3.transform.Rotate(Vector3.forward * 15);
        }
        //if Timesup button is pressed it changes bool wait to true and loads the lock game on screen again
        if (butt== Timesup) 
        {
            wait = true; 
            if (wait == true)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("LockGame");
            }
        }
        //This method is called after every pressed button
        CheckRotation(); 
    }
    /// <summary>
    /// Checks if every lock is rotated to 0 degrees. If all conditions are true, new scene is loaded.
    /// </summary>    
    void CheckRotation()
    {
        // Values need to be forced to int, because Unity gives some random decimals near 0.
        if ((int)lock1.transform.rotation.eulerAngles.z == 0 && (int)lock2.transform.rotation.eulerAngles.z == 0 && (int)lock3.transform.rotation.eulerAngles.z == 0)
        {
            // Not using ChangeScene() method here because of null reference errors, it is one line of code anyway.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
