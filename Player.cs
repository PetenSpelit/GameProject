using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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

    // Use this for initialization, initialize everything here.
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
    }

    // Update is called once per frame
    //Updates movement
    void Update()
    {
        MovementKeys();     
        Move();
    }
    //Sets the player's speed for movement
    public void Move()      
    {
        body.velocity = direction * speed;
    }
    //Movement keys and buttons for different directions.
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
    //Adds an item to next empty slot in the inventory array.
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
    //"Picks up" the items with collision.
    private void OnTriggerEnter2D(Collider2D collision)       
    {
        //When player hits the "Item" tag, gameobject tagged with "Item" gets picked up.
        if (collision.gameObject.CompareTag("Item"))    
        {
            AddToInventory(collision.gameObject);
            item.GetScore(collision.gameObject);
            //shows the name of the item that was picked up
            gamecontroller.PickedUpItem(collision.gameObject);         
        }
        //changes the scene when encountering a door
        if (collision.gameObject.CompareTag("Door"))                 
        {
            gamecontroller.ChangeScene();
        }
    }
    //Prints the contents of the inventory to a Text object.
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
        return score;
    }

}


