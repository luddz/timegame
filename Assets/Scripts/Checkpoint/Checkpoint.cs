using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vector3 newStartPosition;

    private bool isCurrentCheckpoint; 

    // Start is called before the first frame update
    void Start()
    {
        isCurrentCheckpoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !isCurrentCheckpoint) {
            other.gameObject.GetComponent<CharacterMovement>().SetStartPosition(transform.position + newStartPosition);
            isCurrentCheckpoint = true;
        }
    }
}
