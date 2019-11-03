using UnityEngine;
using System.Collections;

/**
 * Control Manager script. 
 * It is used for all input from joystick or keyboard. It is customizable, to fit whatever keys the player
 * deems acceptable.
 */
[System.Serializable]
public class ControlManager : MonoBehaviour {

    // Editor Button Set up
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode jumpAlt;

    // Buttons
    private InputButton leftButton;
    private InputButton rightButton;
    private InputButton upButton;
    private InputButton downButton;
    private InputButton jumpButton;
    private InputButton jumpAltButton;

    [SerializeField] private float joyStickDeadZone = 0.5f;

    void Awake() {
        leftButton = new InputButton(left);
        rightButton = new InputButton(right);
        upButton = new InputButton(up);
        downButton = new InputButton(down);
        jumpButton = new InputButton(jump);
        jumpAltButton = new InputButton(jumpAlt);
    }

    void FixedUpdate () {
        leftButton.Update();
        rightButton.Update();
        upButton.Update();
        downButton.Update();
        jumpButton.Update();
        jumpAltButton.Update();
    }

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
	 * Returns floating point value of vertical movement, control stick and right and left buttons.
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
	 * Returns bool for Jump button down event
	 */
    public bool JumpButtonDown() {

        return jumpButton.GetButtonDown() || jumpAltButton.GetButtonDown();
    }

    /**
    * Returns bool for Jump button up event
    */
    public bool JumpButtonUp() {

        return jumpButton.GetButtonUp() || jumpAltButton.GetButtonUp();
    }

}
