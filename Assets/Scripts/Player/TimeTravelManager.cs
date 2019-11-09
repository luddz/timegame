﻿using System.Collections.Generic;
using UnityEngine;

public class TimeTravelManager: MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private GameObject cloneWrapper;

    void Start() {
    }

    /**
     * Resets time for the player and all clones
     */
    public void ResetTime() {
        // create new clone based on recorded input events from player
        MovementRecorder movementRecorder = player.GetComponent<MovementRecorder>();
        GameObject newClone = Instantiate(clonePrefab);
        newClone.transform.SetParent(cloneWrapper.transform);
        newClone.GetComponent<ControlManager>().SetEvents(movementRecorder.GetRecordedInputEvents());
        CheckpointManager.Instance.AddClone(newClone);

        // reset position and velocities of player
        ResetCharacter(player);
        movementRecorder.ResetRecording();

        // reset position, velocities, and input events for all clones
        foreach (GameObject clone in CheckpointManager.Instance.GetClones()) {
            ResetCharacter(clone);


            ControlManager cloneControlManager = clone.GetComponent<ControlManager>();
            cloneControlManager.StopEvents();
            cloneControlManager.StartEvents();
        }
    }

    /**
     * Resets various values during time reset.
     */
    private void ResetCharacter(GameObject character) {
        character.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        character.layer = 9; //reset layer
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; //reset constraints
        Vector3 startPos = character.GetComponent<CharacterMovement>().GetStartPosition();
        character.transform.position = startPos;
        character.transform.rotation = Quaternion.identity;
    }
}
