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


    public InputButton(KeyCode button) {
        this.button = button;
        pressed = Input.GetKey(button);
    }

    public void Update() {
        if (Input.GetKey(button) && pressed) {
            buttonDown = false;
        }

        if (Input.GetKey(button) && !pressed) { //Button down event
            buttonDown = true;
            pressed = true;
        }

        if (!Input.GetKey(button) && !pressed) {
            buttonUp = false;
        }

        if (!Input.GetKey(button) && pressed) { //Button up event
            buttonUp = true;
            pressed = false;
        }
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
}
