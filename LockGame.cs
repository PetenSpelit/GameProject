using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LockGame : MonoBehaviour
{

    private GameObject lock1;
    private GameObject lock2;
    private GameObject lock3;
    private GameObject lock4;
    private Button TopRight;
    private Button TopLeft;
    private Button MidRight;
    private Button MidLeft;
    private Button BottomRight;
    private Button BottomLeft;
    private Button BottomRight2;
    private Button BottomLeft2;
    private Text Timer;
    private Button restart;
    private float starttime;
    private int rand;
    private int score;
    private Image textbg;
    private bool textbgenabled = true;
    private Dialogue dialogue;
    private bool antispam = true;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //Game objects are being configured
        TopRight = GameObject.Find("TopRight").GetComponent<Button>();
        TopLeft = GameObject.Find("TopLeft").GetComponent<Button>();
        MidRight = GameObject.Find("MidRight").GetComponent<Button>();
        MidLeft = GameObject.Find("MidLeft").GetComponent<Button>();
        BottomRight = GameObject.Find("BottomRight").GetComponent<Button>();
        BottomLeft = GameObject.Find("BottomLeft").GetComponent<Button>();
        BottomRight2 = GameObject.Find("BottomRight2").GetComponent<Button>();
        BottomLeft2 = GameObject.Find("BottomLeft2").GetComponent<Button>();
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        restart = GameObject.Find("RestartGame").GetComponent<Button>();
        lock1 = GameObject.Find("LockNew1");
        lock2 = GameObject.Find("LockNew2");
        lock3 = GameObject.Find("LockNew3");
        lock4 = GameObject.Find("LockNew4");
        textbg = GameObject.Find("TextBG").GetComponent<Image>();
        dialogue = GameObject.Find("TextBG").GetComponent<Dialogue>();
        //Listeners check if buttons are pressed
        TopRight.onClick.AddListener(() => ButtonPressed(TopRight));
        TopLeft.onClick.AddListener(() => ButtonPressed(TopLeft));
        MidRight.onClick.AddListener(() => ButtonPressed(MidRight));
        MidLeft.onClick.AddListener(() => ButtonPressed(MidLeft));
        BottomRight.onClick.AddListener(() => ButtonPressed(BottomRight));
        BottomLeft.onClick.AddListener(() => ButtonPressed(BottomLeft));
        BottomRight2.onClick.AddListener(() => ButtonPressed(BottomRight2));
        BottomLeft2.onClick.AddListener(() => ButtonPressed(BottomLeft2));
        restart.onClick.AddListener(() => ButtonPressed(restart));
        score = Player.staticScore;
        //Sets time for timer by dividing the score by 10.
        rand = Random.Range(0, 5);
        //if the game has just started, the player gets a harder game
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        HideTextScreen();
        if(starttime > 0)
        {
            //Decreases one second from timer every second.
            starttime -= Time.deltaTime;
            //Changes timers text accordingly
            Timer.text = "Time left " + Mathf.Round(starttime);
            //Checks if this method needs to be called
            RestartScene(starttime);
        }
    }
    /// <summary>
    /// Restart checks if timer value is 0, it sets Timesup button active.
    /// </summary>
    /// <param name="starttime"></param>
    public void RestartScene(float starttime)
    {
        if (starttime <= 0)
        {
            if((SceneManager.GetActiveScene().buildIndex == 2) && antispam)
            {
                antispam = false;
                textbg.gameObject.SetActive(true);
                dialogue.DumpText();
            }
            restart.gameObject.SetActive(true);
            TopRight.enabled = !TopRight.enabled;
            TopLeft.enabled = !TopLeft.enabled;
            MidRight.enabled = !MidRight.enabled;
            MidLeft.enabled = !MidLeft.enabled;
            BottomRight.enabled = !BottomRight.enabled;
            BottomLeft.enabled = !BottomLeft.enabled;
            BottomRight2.enabled = !BottomRight2.enabled;
            BottomLeft2.enabled = !BottomLeft2.enabled;
        }
        //this method doesn't work without else. Bool wait is still kept false if Timesup button object isn't set active
        else
        {
            restart.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    /// <summary>
    /// Sets different cases which are randomly selected later
    /// </summary>
    void RandomRotation()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            switch (rand)
            {
                case 5:
                    lock1.transform.Rotate(Vector3.back * 15);
                    break;
                case 4:
                    lock1.transform.Rotate(Vector3.forward * 15);
                    break;
                case 3:
                    lock2.transform.Rotate(Vector3.back * 15);
                    break;
                case 2:
                    lock2.transform.Rotate(Vector3.forward * 15);
                    break;
                case 1:
                    lock3.transform.Rotate(Vector3.back * 15);
                    break;
                default:
                    lock3.transform.Rotate(Vector3.forward * 15);
                    break;
            }
        }
    }
    /// <summary>
    /// This method checks which button is being pressed and it gives instructions to Unity how to move the game object.
    /// </summary>
    /// <param name="butt"></param>
    public void ButtonPressed(Button butt)
    {
        if (butt == TopRight)
        {
            lock1.transform.Rotate(Vector3.back * 15);
            lock3.transform.Rotate(Vector3.forward * 15);
            RandomRotation();
        }
        if (butt == TopLeft)
        {
            lock1.transform.Rotate(Vector3.forward * 15);
            RandomRotation();
        }
        if (butt == MidRight)
        {
            lock2.transform.Rotate(Vector3.back * 15);
            RandomRotation();
        }
        if (butt == MidLeft)
        {
            lock2.transform.Rotate(Vector3.forward * 15);
            lock4.transform.Rotate(Vector3.forward * 15);
            RandomRotation();
        }
        if (butt == BottomRight)
        {
            lock3.transform.Rotate(Vector3.back * 15);
            RandomRotation();
        }
        if (butt == BottomLeft)
        {
            lock3.transform.Rotate(Vector3.forward * 15);
            RandomRotation();
        }
        if (butt == BottomLeft2)
        {
            lock4.transform.Rotate(Vector3.forward * 15);
            lock2.transform.Rotate(Vector3.back * 15);
            RandomRotation();
        }
        if (butt == BottomRight2)
        {
            lock4.transform.Rotate(Vector3.back * 15);
            RandomRotation();
        }
        //if Restart button is pressed it changes bool wait to true and loads the lock game on screen again
        if (butt == restart) // RESTART
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if ((int)lock1.transform.rotation.eulerAngles.z == 0 && (int)lock2.transform.rotation.eulerAngles.z == 0 && (int)lock3.transform.rotation.eulerAngles.z == 0 && (int)lock4.transform.rotation.eulerAngles.z == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }   
        else if ((int)lock1.transform.rotation.eulerAngles.z == 0 && (int)lock2.transform.rotation.eulerAngles.z == 0 && (int)lock3.transform.rotation.eulerAngles.z == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void HideTextScreen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return) && textbg.gameObject.activeSelf)
            {
                if(!textbgenabled)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if (textbgenabled)
                {
                    textbg.gameObject.SetActive(false);
                    starttime = 6f;
                    textbgenabled = false;
                }
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.Return) && textbg.gameObject.activeSelf)
            {
                textbg.gameObject.SetActive(false);
                starttime = score / 10;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.Return) && textbg.gameObject.activeSelf)
            {
                textbg.gameObject.SetActive(false);
                starttime = score / 10;
            }
        }
    }

}