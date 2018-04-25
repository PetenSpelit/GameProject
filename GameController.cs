using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Text DialogueScreen;
    private Text scoreText;
    private int finalScore;
    private GameObject Door;
    private Player inventoryList;
    private Button inventory;
    private Canvas InventoryCanvas;
    private ItemDatabase score;

    // Use this for initialization, simple initialization.
    void Start()
    {
        inventoryList = FindObjectOfType(typeof(Player)) as Player;
        InventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        inventory = GameObject.Find("Inventory").GetComponent<Button>();
        //For the inventory button.
        inventory.onClick.AddListener(() => ShowInventory());
        //Makes the "inventory canvas" invisible @start.
        InventoryCanvas.enabled = false;                    
        DialogueScreen = GameObject.Find("Dialogue").GetComponent<Text>();
        score = FindObjectOfType(typeof(ItemDatabase)) as ItemDatabase;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        //Keeps updating the inventory.
        inventoryList.Inventory();              
    }
    //Toggles inventory canvas on/off by pressing a button.
    public void ShowInventory()             
    {
        ToggleCanvas();
    }
    public void ToggleCanvas()              
    {
        //Toggle inventory canvas.
        InventoryCanvas.enabled = !InventoryCanvas.enabled;     
    }
    public void ChangeScene()
    {
        Debug.Log("doorr");
        SceneManager.LoadScene("LockGame");
    }
    //Shows picked up items in dialogue screen for 4 seconds.
    public void PickedUpItem(GameObject pickedItem)     
    {
        ShowScore();
        DialogueScreen.text = "";
        DialogueScreen.text = "Picked up " + pickedItem.name;
        // 4 second delay.
        StartCoroutine(Delay(4));                       
    }
    // Delay method, some kind of Unity magic.
    IEnumerator Delay(float sec)                        
    {
        yield return new WaitForSeconds(sec);
        DialogueScreen.text = "";
    }
    // Shows the item's score in the dialogue screen
    public void ShowScore()                             
    {
        scoreText.text = "Score: " + inventoryList.ReturnScore();
    }
}

