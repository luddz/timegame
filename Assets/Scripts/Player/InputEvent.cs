using System;
using UnityEngine;

/**
 * Event class. Represents an event for a character. 
 * For example: walk left for 3 seconds.
*/
public class InputEvent {

    public float startTime;
    public float durationTime;
    public Button buttonEnum;

    public InputEvent(Button buttonEnum) {
        this.buttonEnum = buttonEnum;
    }

    public InputEvent(float startTime, float durationTime, Button buttonEnum) {
        this.startTime = startTime;
        this.durationTime = durationTime;
        this.buttonEnum = buttonEnum;
    }

    public InputEvent Clone() {
        return new InputEvent(startTime, durationTime, buttonEnum);
    }
}
