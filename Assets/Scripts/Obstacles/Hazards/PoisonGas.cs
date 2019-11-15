using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** poison gas kills the player when the gas collides with the player */
public class PoisonGas : MonoBehaviour
{

    /**
     * Character has hit the poisongas and dying
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<CharacterMovement>().Die();
        }
    }

}
