using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneControlManager : MonoBehaviour, IControlManager {

    LinkedList<InputEvent> inputEvents;
    LinkedList<IEnumerator> coroutines;
    bool[] isPressed;
    bool[] isDown;
    bool[] isUp;

    void Awake() {
        coroutines = new LinkedList<IEnumerator>();
        isPressed = new bool[(int)Button.nrButtons];
        isDown = new bool[(int)Button.nrButtons];
        isUp = new bool[(int)Button.nrButtons];

        for (int i = 0; i < (int)Button.nrButtons; i++) {
            isPressed[i] = false;
            isDown[i] = false;
            isUp[i] = false;
        }
    }

    /**
     * Sets the input events and initialises the list of coroutines
     */
    public void SetEvents(LinkedList<InputEvent> inputEvents) {
        this.inputEvents = inputEvents;

        foreach (InputEvent inputEvent in inputEvents) {
            coroutines.AddLast(PerformEvent(inputEvent));
        }
    }

    /**
     * starts the button events as coroutines
     */
    public void StartEvents() {
        foreach (IEnumerator coroutine in coroutines) {
            StartCoroutine(coroutine);
        }
    }

    /**
     * stops all coroutines and resets the input lists
     */
    public void StopEvents() {
        foreach (IEnumerator coroutine in coroutines) {
            StopCoroutine(coroutine);
        }

        coroutines.Clear();
        foreach (InputEvent inputEvent in inputEvents) {
            coroutines.AddLast(PerformEvent(inputEvent));
        }

        for (int i = 0; i < (int)Button.nrButtons; i++) {
            isPressed[i] = false;
            isDown[i] = false;
            isUp[i] = false;
        }
    }

    /**
	 * Returns value of horizontal movement.
	 */
    public float Horizontal() {
        if (isPressed[(int)Button.left])
            return -1f;
        else if (isPressed[(int)Button.right])
            return 1f;
        else
            return 0;
    }

    /**
	 * Returns value of vertical movement.
	 */
    public float Vertical() {
        if (isPressed[(int)Button.down])
            return -1f;
        else if (isPressed[(int)Button.up])
            return 1f;
        else
            return 0;
    }

    /**
	 * Returns bool for Jump button down event
	 */
    public bool JumpButtonDown() {
        return isDown[(int)Button.jump] || isDown[(int)Button.jumpAlt];
    }

    /**
    * Returns bool for Jump button up event
    */
    public bool JumpButtonUp() {
        return isUp[(int)Button.jump] || isUp[(int)Button.jumpAlt];
    }

    /**
    * Returns bool for reset time button event (will never be true for clones so we return false)
    */
    public bool IsResetButtonUp() {
        return false;
    }

    /**
     * Coroutine that will change the elements of the bool lists as time moves forward
     */
    private IEnumerator PerformEvent(InputEvent inputEvent) {
        yield return new WaitForSeconds(inputEvent.startTime);
        isPressed[(int)inputEvent.buttonEnum] = true;
        isDown[(int)inputEvent.buttonEnum] = true;

        yield return new WaitForSeconds(Time.fixedDeltaTime);
        isDown[(int)inputEvent.buttonEnum] = false;

        yield return new WaitForSeconds(inputEvent.durationTime - Time.fixedDeltaTime);
        isPressed[(int)inputEvent.buttonEnum] = false;
        isUp[(int)inputEvent.buttonEnum] = true;

        yield return new WaitForSeconds(Time.fixedDeltaTime);
        isUp[(int)inputEvent.buttonEnum] = false;

        yield return null;
    }
}