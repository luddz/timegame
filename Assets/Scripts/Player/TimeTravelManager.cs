using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager: MonoBehaviour
{
    private static TimeTravelManager instance;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private GameObject cloneWrapper;

    private List<SwitchableSystem> switchables;
    private List<SwitchSystem> switches;

    private (GameObject, Checkpoint) currentClone;

    public static TimeTravelManager Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        switchables = new List<SwitchableSystem>();
        switches = new List<SwitchSystem>();
    }

    void Start() {
        CreateClone();
    }

    public void AddSwitch(SwitchSystem toAdd) {
        switches.Add(toAdd);
    }

    public void AddSwitchable(SwitchableSystem toAdd) {
        switchables.Add(toAdd);
    }

    private void CreateClone() {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.transform.SetParent(cloneWrapper.transform);
        newClone.GetComponent<CharacterMovement>().SetStartPosition(CheckpointManager.Instance.GetActiveCheckpoint().GetSpawnPoint());
        newClone.SetActive(false);
        currentClone = (newClone, CheckpointManager.Instance.GetActiveCheckpoint());
    }

    /**
     * Resets time for the player and all clones.
     */
    public void ResetTime(bool createClone) {
        //Play SFX
        AudioManager.Instance.Play("resetPlayer");

        // create new clone based on recorded input events from player
        MovementRecorder movementRecorder = player.GetComponent<MovementRecorder>();

        if (createClone) {
            currentClone.Item1.GetComponent<ControlManager>().SetEvents(movementRecorder.GetRecordedInputEvents());
            CheckpointManager.Instance.AddClone(currentClone.Item1, currentClone.Item2);
            CreateClone();
        } else {
            Destroy(currentClone.Item1);
            CreateClone();
        }

        //Reset Switches
        foreach(SwitchSystem s in switches) {
            s.ResetSwitch();
        }

        //Reset Switchables
        foreach(SwitchableSystem s in switchables) {
            s.ResetSwitchable();
        }

        //Reset Camera
        CameraManager.Instance.SetPivot(CheckpointManager.Instance.GetCheckpointPivot());

        //Reset Audio
        AudioManager.Instance.SetThemePitch(1.0f);

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

    /**
     * Resets positions for all clones
     */
    public void ResetPositions() {
        foreach (GameObject clone in CheckpointManager.Instance.GetClones()) {
            clone.GetComponent<ControlManager>().StopEvents();
            clone.transform.position = clone.GetComponent<CharacterMovement>().GetStartPosition();
        }
    }
}
