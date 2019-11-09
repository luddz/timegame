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
    public bool isMovementState;
    public MovementState movementState;

    public InputEvent(Button buttonEnum) {
        this.buttonEnum = buttonEnum;
        isMovementState = false;
    }

    public InputEvent(float startTime, MovementState movementState) {
        this.startTime = startTime;
        this.movementState = movementState;
        isMovementState = true;
    }

    public InputEvent(InputEvent other) {
        startTime = other.startTime;
        durationTime = other.durationTime;
        buttonEnum = other.buttonEnum;
        isMovementState = other.isMovementState;
        if(other.isMovementState)
            movementState = new MovementState(other.movementState);
    }

    public InputEvent Clone() {
        return new InputEvent(this);
    }
}
