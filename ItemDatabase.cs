using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private int score = 0;
    private List<Item> database;
    private Item horseshoe;
    private Item key;
    private Item carrot;
    private Item beanie;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        InitializeDatabase();
    }
    /// <summary>
    /// Iterates trough The whole database to return the score of database
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns> Scrore of the database </returns>
    public int GetDataBaseScore(GameObject gameObject)
    {
        foreach (Item item in database)
        {
            this.score = item.ItemScore;
        }
        return this.score;
    }
    /// <summary>
    /// Compares names of items in database to the name of gameObject provided and returns a score of item.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns> Total inventory score </returns>
    public int GetScore(GameObject gameObject)
    {
        if(gameObject != null)
        {
            foreach (Item item in database)
            {
                if (item.ItemName == gameObject.name)
                {
                    return item.ItemScore;
                }
            }
        }
        
        return 0;
    }
    /// <summary>
    /// Returns a gameObject, aka Item.
    /// </summary>
    /// <returns> GameObject (Should be item) </returns>
    public GameObject GetItem()
    {
        Debug.Log(gameObject.name);
        return gameObject;
    }

    /// <summary>
    /// InitializeDatabase does what the name suggests.
    /// All Item objects are created and added to the database list here.
    /// </summary>
    private void InitializeDatabase()
    {
        this.database = new List<Item>();
        this.horseshoe = new Item("Horseshoe", 50);
        this.key = new Item("Key", 30);
        this.carrot = new Item("Carrot", 20);
        this.beanie = new Item("Beanie", 60);
        database.Add(horseshoe);
        database.Add(key);
        database.Add(carrot);
        database.Add(beanie);
    }

}