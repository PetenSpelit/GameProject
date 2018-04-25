/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int score = 0;

    // Use this for initialization
    void Start()
    {

    }
    // Returns the score of an item.
    public int GetScore(GameObject gameObject)
    {
        if (gameObject.name == "Cheese")
        {
            this.score = 50;
        }
        if (gameObject.name == "LockNew")
        {
            this.score = 30;
        }
        return this.score;
    }
    public int ReturnScore()
    {
        return score;
    }
    //Returns a gameObject, aka Item.
    //apparently this doesn't work...
    public GameObject GetItem()
    {
        Debug.Log(gameObject.name);
        return gameObject;
    }

}
*/