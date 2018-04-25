using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Item
{
    private string itemName;
    private int itemScore;

    public Item(string giveName, int giveScore)
    {
        this.itemName = giveName;
        this.itemScore = giveScore;
    }
    public int ItemScore { get { return itemScore; } set { itemScore = value; } }
    public string ItemName { get { return itemName; } set { itemName = value; } }
}