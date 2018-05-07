using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Dialogue dialogue;
    private bool inDialogue;
    private Collider2D npcCollider;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        npcCollider = GetComponent<Collider2D>();
        npcCollider.GetComponent<Collider2D>().enabled = true;
        dialogue = FindObjectOfType(typeof(Dialogue)) as Dialogue;
        this.inDialogue = false;
    }
    /// <summary>
    /// Starts dialogue and sets inDialogue to true or false.
    /// </summary>
    public void StartDialogue()
    {
        inDialogue = true;
        dialogue.RunDialogue();
        npcCollider.GetComponent<Collider2D>().enabled = false;
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
    /// <summary>
    /// Set/get bool.
    /// </summary>
    public bool InDialogue
    {
        get { return inDialogue; }
        set { inDialogue = value; }
    }
}