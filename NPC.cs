using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private bool inDialogue;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        this.inDialogue = false;
    }
    /// <summary>
    /// Starts dialogue and sets inDialogue to true or false.
    /// </summary>
    public void StartDialogue()
    {
        //asdasd
        inDialogue = true;
        if(Input.GetKey(KeyCode.Return))
        {
            inDialogue = false;
        }
        // Put stuff here
        
    }
    /// <summary>
    ///  If player is in conversation returns true, so the player cannot move anymore (see Player class).
    /// </summary>
    /// <returns></returns>
    public bool InDiscussion()
    {
        if (inDialogue)
        {
            return true;
        }
        else { return false; }
    }
}