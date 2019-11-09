using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Singleton for handling checkpoints
 */
public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance; //singleton instance

    [SerializeField] private Checkpoint startingCheckpoint;

    private Checkpoint activeCheckpoint;
    private Dictionary<Checkpoint, List<GameObject>> clones;

    public static CheckpointManager Instance { get { return instance; } }

    void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Start() {
        clones = new Dictionary<Checkpoint, List<GameObject>>();
        SetActiveCheckpoint(startingCheckpoint);
    }

    public bool IsActiveCheckpoint(Checkpoint checkpoint) {
        return checkpoint == activeCheckpoint;
    }

    public void SetActiveCheckpoint(Checkpoint checkpoint) {
        activeCheckpoint = checkpoint;
        if (!clones.ContainsKey(activeCheckpoint))
            clones.Add(activeCheckpoint, new List<GameObject>());
    }

    public List<GameObject> GetClones () {
        List<GameObject> result = new List<GameObject>();
        foreach(KeyValuePair<Checkpoint, List<GameObject>> entry in clones) {
            result.AddRange(entry.Value);
        }
        return result;
    }

    public void AddClone(GameObject clone) {
        clones[activeCheckpoint].Add(clone);
    }

    public void ClearCheckpoint() {
        foreach(GameObject clone in clones[activeCheckpoint]) {
            Destroy(clone);
        }
        clones[activeCheckpoint].Clear();
    }

}
