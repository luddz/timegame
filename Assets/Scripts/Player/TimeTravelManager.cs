using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager: MonoBehaviour
{
    private static TimeTravelManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private GameObject cloneWrapper;

    public static TimeTravelManager Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Start() {
    }

    /**
     * Resets time for the player and all clones.
     */
    public void ResetTime(bool createClone) {
        //Play SFX
        AudioManager.Instance.Play("resetPlayer");
        
        // create new clone based on recorded input events from player
        MovementRecorder movementRecorder = player.GetComponent<MovementRecorder>();
        movementRecorder.StopRecording();

        if (createClone) {
            GameObject newClone = Instantiate(clonePrefab);
            newClone.transform.SetParent(cloneWrapper.transform);
            newClone.GetComponent<CharacterMovement>().SetStartPosition(CheckpointManager.Instance.GetActiveCheckpoint().GetSpawnPoint());
            newClone.GetComponent<ControlManager>().SetEvents(movementRecorder.GetRecordedInputEvents());
            CheckpointManager.Instance.AddClone(newClone);
        }

        //Reset Turrets
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        foreach(GameObject turret in turrets) {
            turret.GetComponent<Turret>().ResetTurret();
        }

        // reset position and velocities of player
        player.GetComponent<CharacterMovement> ().ResetCharacter();
        movementRecorder.ResetRecording();
        // reset position, velocities, and input events for all clones
        foreach (GameObject clone in CheckpointManager.Instance.GetClones()) {
            ControlManager cloneControlManager = clone.GetComponent<ControlManager>();
            cloneControlManager.StopEvents();
            clone.GetComponent<CharacterMovement>().ResetCharacter();
            cloneControlManager.StartEvents();
        }
    }
}
