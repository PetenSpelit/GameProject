using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] shows the variable in Unity inspector, even when the variable is private.
    private GameController gamecontroller;
    private Vector2 direction;
    [SerializeField]
    private float speed;
    private Rigidbody2D body;
    private ButtonController Up;
    private ButtonController Down;
    private ButtonController Left;
    private ButtonController Right;
    private Text inventoryList;
    [SerializeField]
    private GameObject[] inventory;
    private ItemDatabase item;
    private int score = 0;
    private NPC npc;
    public static int staticScore = 0;

    /// <summary>
    /// Use this for initialization, initialize everything here.
    /// </summary>
    void Start()
    {
        inventory = new GameObject[10];
        body = GetComponent<Rigidbody2D>();
        Up = GameObject.Find("Up").GetComponent<ButtonController>();
        Down = GameObject.Find("Down").GetComponent<ButtonController>();
        Left = GameObject.Find("Left").GetComponent<ButtonController>();
        Right = GameObject.Find("Right").GetComponent<ButtonController>();
        inventoryList = GameObject.Find("InventoryList").GetComponent<Text>();
        gamecontroller = FindObjectOfType(typeof(GameController)) as GameController;
        item = FindObjectOfType(typeof(ItemDatabase)) as ItemDatabase;
        npc = FindObjectOfType(typeof(NPC)) as NPC;
    }

    /// <summary>
    /// Updates movement
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // If InDiscussion() is false, player can move. When dialogue starts player cannot move anymore.
        if(!npc.InDiscussion())
        {
            MovementKeys();
            Move();
        }
        else
        {
           Stop();
        }
    }
    /// <summary>
    /// Sets the player's speed for movement
    /// </summary>
    public void Move()      
    {
        body.velocity = direction * speed;
    }
    /// <summary>
    /// Sets the player's speed to 0
    /// </summary>
    public void Stop()
    {
        body.velocity = direction * 0;
    }
    /// <summary>
    /// Movement keys and buttons for different directions.
    /// </summary>
    public void MovementKeys()      
    {
        //Without this line, speed would increase constantly.
        direction = Vector2.zero;   

        if (Input.GetKey(KeyCode.A) || Left.ButtonPressed)
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Right.ButtonPressed)
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W) || Up.ButtonPressed)
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Down.ButtonPressed)
        {
            direction += Vector2.down;
        }

    }
    /// <summary>
    /// Adds an item to next empty slot in the inventory array.
    /// </summary>
    /// <param name="pickItem"></param>
    public void AddToInventory(GameObject pickItem)   
    {                                                 
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = pickItem;
                break;
            }
        }
    }
    /// <summary>
    /// Does different things when player collides with gameObjects.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)       
    {
        //When player hits the "Item" tag, gameobject tagged with "Item" gets picked up.
        if (collision.gameObject.CompareTag("Item"))    
        {
            AddToInventory(collision.gameObject);
            //Gets the score of the item that is picked up
            item.GetScore(collision.gameObject);
            //Shows the name of the item that is picked up
            gamecontroller.PickedUpItem(collision.gameObject);
            //Hides the item after it is picked up
            gamecontroller.HideItem(collision.gameObject);
        }
        //changes the scene when encountering a door
        if (collision.gameObject.CompareTag("Door"))                 
        {
            foreach (GameObject temp in inventory)
            {
                if(temp != null)
                {
                    if (temp.name == "Key")
                    {
                        gamecontroller.ChangeScene();
                    }
                }
            }
        }
        //Starts dialogue with NPC when encountering one
        if (collision.gameObject.CompareTag("NPC"))
        {
            npc.StartDialogue();
        }
    }
    /// <summary>
    /// Prints the contents of the inventory to a Text object.
    /// </summary>
    public void Inventory()                     
    {
        inventoryList.text = "Inventory:\n";
        foreach (GameObject InventoryItem in inventory)
        {
            //To avoid null reference errors.
            if (InventoryItem != null)          
            {
                inventoryList.text = inventoryList.text + InventoryItem.name + "\n";
            }
        }
    }
    /// <summary>
    /// Returns score for printing.
    /// </summary>
    /// <returns>Item score</returns>
    public int ReturnScore()
    {
        score = 0;
        foreach (GameObject temp in inventory)
        {
            score = score + item.GetScore(temp);
        }
        staticScore = score;
        return score;
    }

}


