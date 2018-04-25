using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool buttonPressed;

    //button is pressed
    public void OnPointerDown(PointerEventData b)       
    {
        buttonPressed = true;
    }
    //button isn't pressed
    public void OnPointerUp(PointerEventData b)         
    {
        buttonPressed = false;
    }
    //returns boolean for button presses
    public bool ButtonPressed                           
    {
        get
        {
            return buttonPressed;
        }
        
    }
}
