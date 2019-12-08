using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class that handles input for one button
 */
 [System.Serializable]
public class InputButton {
    private KeyCode button;
    private bool pressed;
    private bool buttonDown;
    private bool buttonUp;
    private bool forcePressed;
    private bool skipUpdate;


    public InputButton(KeyCode button) {
        this.button = button;
        forcePressed = false;
    }

    public void Update() {
        if(!skipUpdate)
            buttonDown = (Input.GetKeyDown(button));

        pressed = (Input.GetKey(button) || forcePressed);

        if(!skipUpdate)
            buttonUp = (Input.GetKeyUp(button));

        skipUpdate = false;
    }

    public void SetButtonDown(bool buttonDown) {
        this.buttonDown = buttonDown;
    }

    public void SetButtonUp(bool buttonUp) {
        this.buttonUp = buttonUp;
    }

    public void SetButton(bool pressed) {
        this.pressed = pressed;
    }

    public bool GetButtonDown() {
        return buttonDown;
    }

    public bool GetButtonUp() {
        return buttonUp;
    }

    public bool GetButton() {
        return pressed;
    }

    public KeyCode GetKeyCode() {
        return button;
    }

    public void ForcePress(bool press) {
        if(forcePressed != press) {
            skipUpdate = true;
            if(!forcePressed) {
                buttonDown = true;
            } else {
                buttonUp = true;
            }
        }
        forcePressed = press;
    }
}
