using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool buttonPressed;

    /// <summary>
    /// Button is pressed
    /// </summary>
    /// <param name="b"></param>
    public void OnPointerDown(PointerEventData b)       
    {
        buttonPressed = true;
    }
    /// <summary>
    /// Button isn't pressed (anymore)
    /// </summary>
    /// <param name="b"></param>
    public void OnPointerUp(PointerEventData b)         
    {
        buttonPressed = false;
    }
    /// <summary>
    /// Returns boolean for button presses
    /// </summary>
    public bool ButtonPressed                           
    {
        get
        {
            return buttonPressed;
        }
        set
        {
            buttonPressed = value;
        }
    }
}
