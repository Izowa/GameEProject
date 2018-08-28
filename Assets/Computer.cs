using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is the a script to allow for cumputers with pop up UI it can spawn any UI and has a light that turns on
//when in use
public class Computer : Interactable {

    //serilizable varbibles for setting in unity
    [SerializeField] GameObject screen;
    [SerializeField] Light screenLight;
    //private varbibles that the object nees
    bool on;

    //Overide the use method of Interactable to specilize for computers
    public override void use()
    {
        Debug.Log("Computer");
        on = true;
        screenLight.enabled = on;
        screen.SetActive(on);
    }

    //an update cycle to allow for the computer to be controlled by the contoller
    public void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                on = false;
                screenLight.enabled = on;
                screen.SetActive(on);
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                screen.GetComponentsInChildren<Button>()[0].onClick.Invoke();
                on = false;
                screenLight.enabled = on;
                screen.SetActive(on);
            }
        }
    }

    //Overide the use method of OnTriggerExit to turn off the light
    //bug: the light will turn of if another player comes near then exits but should also push the other player away
    //possible fix: Have the computer lock to the player using it but could be annoying
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (on)
            {
                on = false;
                screenLight.enabled = on;
                screen.SetActive(on);              
            }
            other.GetComponentInParent<Player>().setInteractable(null);
        }
    }
}
