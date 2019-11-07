using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Enum keeping track of all buttons, nrButtons is how many registered buttons there is in total (it has to be last!)
 */
public enum Button {
    left, right, up, down, jump, jumpAlt, resetTime, nrButtons
}

public class ControlManager : MonoBehaviour {

    [SerializeField] private bool isPlayer;

    // Editor Button Set up
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode jumpAlt;
    [SerializeField] private KeyCode resetTime;

    [SerializeField] private float joyStickDeadZone = 0.5f;

    private KeyCode[] keyCodes;
    private InputButton[] inputButtons;
    private LinkedList<InputEvent> inputEvents;

    void Awake() {
        keyCodes = new KeyCode[] { left, right, up, down, jump, jumpAlt, resetTime };
        inputButtons = new InputButton[(int)Button.nrButtons];

        for (int i = 0; i < (int)Button.nrButtons; i++) {
            inputButtons[i] = new InputButton(keyCodes[i]);
        }

        // if this is not the player the update function will be skipped
        if (!isPlayer) {
            enabled = false;
        }
    }

    /**
     * Update function will only be called if this gameObject is player (enabled is set to false otherwise)
     */
    void Update() {
        for (int i = 0; i < (int)Button.nrButtons; i++) {
            inputButtons[i].Update();
        }
    }

    /**
     * Sets the input events and initialises the list of coroutines
     */
    public void SetEvents(LinkedList<InputEvent> inputEvents) {
        this.inputEvents = inputEvents;
    }

    /**
     * starts the button events as coroutines
     */
    public void StartEvents() {
        foreach (InputEvent inputEvent in inputEvents) {
            StartCoroutine(PerformEvent(inputEvent));
        }
    }

    /**
     * stops all coroutines and resets the input lists
     */
    public void StopEvents() {
        StopAllCoroutines();

        for (int i = 0; i < (int)Button.nrButtons; i++) {
            inputButtons[i].SetButton(false);
            inputButtons[i].SetButtonDown(false);
            inputButtons[i].SetButtonUp(false);
        }
    }

    /**
	 * Returns value of horizontal movement.
	 */
    public float Horizontal() {
        if (inputButtons[(int)Button.left].GetButton())
            return -1f;
        else if (inputButtons[(int)Button.right].GetButton())
            return 1f;
        else
            return 0;
    }

    /**
	 * Returns value of vertical movement.
	 */
    public float Vertical() {
        if (inputButtons[(int)Button.down].GetButton())
            return -1f;
        else if (inputButtons[(int)Button.up].GetButton())
            return 1f;
        else
            return 0;
    }

    /**
	 * Returns bool for Jump button down event
	 */
    public bool JumpButtonDown() {
        return inputButtons[(int)Button.jump].GetButtonDown() || inputButtons[(int)Button.jumpAlt].GetButtonDown();
    }

    /**
    * Returns bool for Jump button up event
    */
    public bool JumpButtonUp() {
        return inputButtons[(int)Button.jump].GetButtonUp() || inputButtons[(int)Button.jumpAlt].GetButtonUp();
    }

    /**
    * Returns bool for reset time button event
    */
    public bool IsResetButtonUp() {
        return inputButtons[(int)Button.resetTime].GetButtonUp();
    }

    /**
     * Returns a list of all registered buttons
     */
    public InputButton[] GetButtons() {
        return inputButtons;
    }

    /**
     * Coroutine that will change the elements of the bool lists as time moves forward
     */
    private IEnumerator PerformEvent(InputEvent inputEvent) {
        yield return new WaitForSeconds(inputEvent.startTime);

        if(inputEvent.isPositionPoll) {
            transform.position = inputEvent.pos;
            GetComponent<Rigidbody2D>().velocity = inputEvent.vel;
        }

        else {
            inputButtons[(int)inputEvent.buttonEnum].SetButton(true);
            inputButtons[(int)inputEvent.buttonEnum].SetButtonDown(true);

            yield return null;
            inputButtons[(int)inputEvent.buttonEnum].SetButtonDown(false);

            yield return new WaitForSeconds(inputEvent.durationTime - Time.deltaTime);
            inputButtons[(int)inputEvent.buttonEnum].SetButton(false);
            inputButtons[(int)inputEvent.buttonEnum].SetButtonUp(true);

            yield return null;
            inputButtons[(int)inputEvent.buttonEnum].SetButtonUp(false);
        }
    }
}