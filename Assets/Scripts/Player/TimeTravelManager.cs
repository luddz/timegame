using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager: MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private GameObject cloneWrapper;

    void Start() {
    }

    /**
     * Resets time for the player and all clones.
     */
    public void ResetTime(bool createClone) {
        // create new clone based on recorded input events from player
        MovementRecorder movementRecorder = player.GetComponent<MovementRecorder>();
        if (createClone) {
            GameObject newClone = Instantiate(clonePrefab);
            newClone.transform.SetParent(cloneWrapper.transform);
            newClone.GetComponent<ControlManager>().SetEvents(movementRecorder.GetRecordedInputEvents());
            CheckpointManager.Instance.AddClone(newClone);
        }

        // reset position and velocities of player
        player.GetComponent<CharacterMovement> ().ResetCharacter();
        movementRecorder.ResetRecording();

        // reset position, velocities, and input events for all clones
        foreach (GameObject clone in CheckpointManager.Instance.GetClones()) {
            clone.GetComponent<CharacterMovement>().ResetCharacter();


            ControlManager cloneControlManager = clone.GetComponent<ControlManager>();
            cloneControlManager.StopEvents();
            cloneControlManager.StartEvents();
        }
    }
}
