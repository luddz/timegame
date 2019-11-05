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
    public bool isPositionPoll;
    public Vector3 pos;
    public Vector3 vel;

    public InputEvent(Button buttonEnum) {
        this.buttonEnum = buttonEnum;
        isPositionPoll = false;
    }

    public InputEvent(float startTime, Vector3 pos, Vector3 vel) {
        this.startTime = startTime;
        this.pos = pos;
        this.vel = vel;
        isPositionPoll = true;
    }

    public InputEvent(InputEvent other) {
        startTime = other.startTime;
        durationTime = other.durationTime;
        buttonEnum = other.buttonEnum;
        isPositionPoll = other.isPositionPoll;
        pos = new Vector3(other.pos.x, other.pos.y, other.pos.z);
        vel = new Vector3(other.vel.x, other.vel.y, other.vel.z);
    }

    public InputEvent Clone() {
        return new InputEvent(this);
    }
}
