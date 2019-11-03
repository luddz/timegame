using UnityEngine;
using System.Collections;

/**
 * Control Manager script. 
 * It is used for all input from joystick or keyboard. It is customizable, to fit whatever keys the player
 * deems acceptable.
 */
[System.Serializable]
public class ControlManager : MonoBehaviour {

    // Buttons
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode shoot;
    [SerializeField] private KeyCode jumpAlt;
    [SerializeField] private KeyCode shootAlt;

    [SerializeField] private float joyStickDeadZone = 0.5f;

    /**
	 * Returns floating point value of horizontal movement, control stick and right and left buttons.
	 */
    public float Horizontal() {
        if (Input.GetKey(left))
            return -1f;
        else if (Input.GetKey(right))
            return 1f;
        else if (Mathf.Abs(Input.GetAxisRaw("LeftStickX")) < joyStickDeadZone)
            return 0;
        else {
            if (Input.GetAxisRaw("LeftStickX") > 0)
                return Input.GetAxisRaw("LeftStickX") / (1 - joyStickDeadZone) - joyStickDeadZone / (1 - joyStickDeadZone); //linear equation so that when axis is at deadzone returns zero, and then scales correctly to 1
            else
                return Input.GetAxisRaw("LeftStickX") / (1 - joyStickDeadZone) + joyStickDeadZone / (1 - joyStickDeadZone);
        }
    }

    /**
	 * Returns floating point value of verticaö movement, control stick and right and left buttons.
	 */
    public float Vertical() {
        if (Input.GetKey(down))
            return -1f;
        else if (Input.GetKey(up))
            return 1f;
        else if (Mathf.Abs(Input.GetAxisRaw("LeftStickY" )) < joyStickDeadZone)
            return 0;
        else {
            if (Input.GetAxisRaw("LeftStickY") > 0)
                return -(Input.GetAxisRaw("LeftStickY") / (1 - joyStickDeadZone) - joyStickDeadZone / (1 - joyStickDeadZone)); //linear equation so that when axis is at deadzone returns zero, and then scales correctly to 1
            else
                return -(Input.GetAxisRaw("LeftStickY") / (1 - joyStickDeadZone) + joyStickDeadZone / (1 - joyStickDeadZone));
        }
    }

    /**
	 * Returns the keycode for the jump button.
	 */
    public KeyCode JumpButton() {
        
        if (Input.GetKey(jump) || Input.GetKeyUp(jump))
            return jump;
        else
            return jumpAlt;
    }

    /**
	 * Returns the keycode for the shoot button.
	 */
    public KeyCode ShootButton() {

        if (Input.GetKey(shoot) || Input.GetKeyUp(shoot))
            return shoot;
        else
            return shootAlt;
    }

}
