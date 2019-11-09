using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vector3 newStartPosition;

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
        if(other.tag == "Player" && !CheckpointManager.Instance.IsActiveCheckpoint(this)) {
            CheckpointManager.Instance.SetActiveCheckpoint(this); //Set checkpoint first
            other.gameObject.GetComponent<CharacterMovement>().SetStartPosition(transform.position + newStartPosition); //Then Set Start Position and Reset
        }
    }
}
