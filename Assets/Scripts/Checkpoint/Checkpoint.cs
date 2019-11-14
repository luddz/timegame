using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Entered a Checkpoint
     */
    void OnTriggerEnter2D(Collider2D other) {
        //TODO add an animation or some buffer period so you don't suddenly snap to the startposition
        if(PlayerManager.Instance.IsPlayer(other.gameObject) && !CheckpointManager.Instance.IsActiveCheckpoint(this)) {
            other.gameObject.GetComponent<CharacterMovement>().SetStartPosition(GetSpawnPoint(), this); //Then Set Start Position and Reset
        }
    }

    //Gets the position that the checkpoint spawns from.
    public Vector3 GetSpawnPoint() {
        return transform.position + positionOffset;
    }
}
