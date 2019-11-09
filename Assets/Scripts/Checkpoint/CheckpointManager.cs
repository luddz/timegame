using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Singleton for handling checkpoints
 */
public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance; //singleton instance

    private Checkpoint activeCheckpoint;

    public static CheckpointManager Instance { get { return instance; } }

    void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    public bool IsActiveCheckpoint(Checkpoint checkpoint) {
        return checkpoint == activeCheckpoint;
    }

    public void SetActiveCheckpoint(Checkpoint checkpoint) {
        activeCheckpoint = checkpoint;
    }
}
