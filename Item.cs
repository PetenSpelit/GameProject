using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Item
{
    private string itemName;
    private int itemScore;

    /// <summary>
    /// Contstuctor for item name and score.
    /// </summary>
    /// <param name="giveName"></param>
    /// <param name="giveScore"></param>
    public Item(string giveName, int giveScore)
    {
        this.itemName = giveName;
        this.itemScore = giveScore;
    }
    /// <summary>
    /// Returns item's score.
    /// </summary>
    public int ItemScore { get { return itemScore; } set { itemScore = value; } }
    /// <summary>
    /// Returns item's name.
    /// </summary>
    public string ItemName { get { return itemName; } set { itemName = value; } }
}