using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlatform : BalanceComponent
{
    [SerializeField] uint weight;

    public override uint GetWeight() {
        return weight;
    }

    public override bool IsFulfilled() {
        return true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 9) //Other is player or clone
            weight++;

        RequestUpdate();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 9) //Other is player or clone
            weight--;

        RequestUpdate();
    }
}
