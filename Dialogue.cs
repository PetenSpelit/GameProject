﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public Player player;
    private NPC npc;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;
        npc = FindObjectOfType(typeof(NPC)) as NPC;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }
    /// <summary>
    /// Just a wait/delay Unity method.
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        foreach(string texts in textLines)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            theText.text = textLines[currentLine];
            currentLine += 1;
            if (currentLine > endAtLine)
            {
                npc.InDialogue = false;
                yield return new WaitForSeconds(3f);
                theText.text = "";
            }
            yield return new WaitForSeconds(1f);
        }
            
    }
    /// <summary>
    /// Starts dialogue when enter is pressed. Goes through the .txt file.
    /// </summary>
    public void RunDialogue()
    {
        theText.text = "Press enter to start conversation.";
        StartCoroutine(Wait());
    }
}