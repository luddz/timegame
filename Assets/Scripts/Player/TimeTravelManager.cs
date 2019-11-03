using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager: MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private GameObject cloneWrapper;
    private List<GameObject> clones;

    void Start() {
        clones = new List<GameObject>();
    }

    /**
     * Resets time for the player and all clones
     */
    public void ResetTime() {
        // create new clone based on recorded input events from player
        MovementRecorder movementRecorder = player.GetComponent<MovementRecorder>();
        GameObject newClone = Instantiate(clonePrefab);
        newClone.transform.SetParent(cloneWrapper.transform);
        newClone.GetComponent<CloneControlManager>().SetEvents(movementRecorder.GetRecordedInputEvents());
        clones.Add(newClone);

        // reset position and velocities of player
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Vector3 startPos = player.GetComponent<CharacterMovement>().GetStartPosition();
        player.transform.position = startPos;
        movementRecorder.ResetRecording();

        // reset position, velocities, and input events for all clones
        foreach (GameObject clone in clones) {
            clone.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            startPos = clone.GetComponent<CharacterMovement>().GetStartPosition();
            clone.transform.position = startPos;

            CloneControlManager cloneControlManager = clone.GetComponent<CloneControlManager>();
            cloneControlManager.StopEvents();
            cloneControlManager.StartEvents();
        }
    }
}
