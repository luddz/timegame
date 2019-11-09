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

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !CheckpointManager.Instance.IsActiveCheckpoint(this)) {
            other.gameObject.GetComponent<CharacterMovement>().SetStartPosition(transform.position + newStartPosition);
            CheckpointManager.Instance.SetActiveCheckpoint(this);
        }
    }
}
