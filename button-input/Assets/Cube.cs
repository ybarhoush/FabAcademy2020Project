using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Cube : MonoBehaviour
{
    // set controls equal to a new player controls object 
    PlayerControls controls;

    void Awake()
    {
        //... created a player controls object to refer to
        controls = new PlayerControls();
        //following action map structure, access game play and then access the grow action
        //inside Grow function, transform dot local scale ... for the context, use lambda expression
        controls.GamePlay.Grow.performed += ctx => Grow();
        
    }

    //add a function to Grow that will be triggered when the action is performed
    void Grow()
    {
        transform.localScale *= 1.1f;
    }
    //make sure to enable and disable input actions whenever this object gets enabled or disabled
    private void OnEnable()
    {
        controls.GamePlay.Enable();
    }
    //make sure to enable and disable input actions whenever this object gets enabled or disabled
    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }
}