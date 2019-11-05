using System.Collections.Generic;
using UnityEngine;

public class MovementRecorder : MonoBehaviour {

    private float runTime;
    private InputButton[] inputButtons;
    private InputEvent[] activeInputEvents;
    LinkedList<InputEvent> recordedInputEvents;

    // Start is called before the first frame update
    void Start() {
        runTime = 0;
        recordedInputEvents = new LinkedList<InputEvent>();
        inputButtons = GetComponent<PlayerControlManager>().getButtons();

        // active input events is a list of input events corresponding to the number of possible inputs.
        activeInputEvents = new InputEvent[inputButtons.Length];
        for (int i = 0; i < activeInputEvents.Length; i++) {
            activeInputEvents[i] = new InputEvent((Button)i);
        }
    }

    void FixedUpdate() {
        // update runtime
        runTime += Time.fixedDeltaTime;

        // check status of each button for the current update
        for (int i = 0; i < inputButtons.Length; i++) {

            // If button just started beeing pressed, then reset this input event 
            if (inputButtons[i].GetButtonDown()) {
                activeInputEvents[i].startTime = runTime;
                activeInputEvents[i].durationTime = 0;
            }

            // if button is currently beeing pressed, then update duration time
            else if (inputButtons[i].GetButton()) {
                activeInputEvents[i].durationTime += Time.fixedDeltaTime;
            }

            // if button just stopped beeing pressed, then save the input event to the list
            else if (inputButtons[i].GetButtonUp()) {
                recordedInputEvents.AddLast(activeInputEvents[i].Clone());
            }
        }
    }

    /**
     * resets the recording and all active input events for valid inputs
     */
    public void ResetRecording() {
        runTime = 0;

        // check status of each button
        for (int i = 0; i < inputButtons.Length; i++) {
            // if button is currently beeing pressed, then save the input event to the list
            if (inputButtons[i].GetButton()) {
                recordedInputEvents.AddLast(activeInputEvents[i].Clone());
            }
        }

        // resets all active 
        foreach (InputEvent inputEvent in activeInputEvents) {
            inputEvent.startTime = 0;
            inputEvent.durationTime = 0;
        }

        recordedInputEvents = new LinkedList<InputEvent>();
    }

    public LinkedList<InputEvent> GetRecordedInputEvents() {
        LinkedList<InputEvent> inputEvents = new LinkedList<InputEvent>();

        foreach (InputEvent inputEvent in recordedInputEvents) {
            inputEvents.AddLast(inputEvent.Clone());
        }

        return inputEvents;
    }
}
