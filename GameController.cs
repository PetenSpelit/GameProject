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

    /// <summary>
    /// Use this for initialization, simple initialization.
    /// </summary>    
    void Start()
    {
        inventoryList = FindObjectOfType(typeof(Player)) as Player;
        inventory = GameObject.Find("InventoryButton").GetComponent<Button>();
        //For the inventory button.
        inventory.onClick.AddListener(() => ShowInventory());
        InventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        InventoryCanvas.enabled = false;
        //Makes the "inventory canvas" invisible @start.                    
        DialogueScreen = GameObject.Find("Dialogue").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Keeps updating the inventory.
        inventoryList.Inventory();              
    }
    /// <summary>
    /// Toggles inventory on/off by pressing a button.
    /// </summary>
    public void ShowInventory()             
    {
        ToggleCanvas();
    }
    /// <summary>
    /// Method for toggling the canvas (in this case it means inventory).
    /// </summary>
    public void ToggleCanvas()              
    {
        //Toggle inventory canvas.
        InventoryCanvas.enabled = !InventoryCanvas.enabled;     
    }
    /// <summary>
    /// Method for changing scenes.
    /// </summary>
    public void ChangeScene()
    {
        //Loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /// <summary>
    /// Shows picked up items in dialogue screen for 4 seconds.
    /// </summary>
    /// <param name="pickedItem"></param>
    public void PickedUpItem(GameObject pickedItem)     
    {
        ShowScore();
        DialogueScreen.text = "";
        DialogueScreen.text = "Picked up " + pickedItem.name;
        // 4 second delay.
        StartCoroutine(Delay(3));                       
    }
    /// <summary>
    /// Delay method, some kind of Unity magic.
    /// </summary>
    /// <param name="sec"></param>
    /// <returns></returns>
    IEnumerator Delay(float sec)                        
    {
        yield return new WaitForSeconds(sec);
        DialogueScreen.text = "";
    }
    /// <summary>
    /// Shows the item's score in the dialogue screen
    /// </summary>
    public void ShowScore()                             
    {
        scoreText.text = "Score: " + inventoryList.ReturnScore();
    }
    /// <summary>
    /// Sets the renderer to FALSE, so the gameobject isn't visible anymore
    /// </summary>
    /// <param name="gameObject"></param>
    public void HideItem(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}

