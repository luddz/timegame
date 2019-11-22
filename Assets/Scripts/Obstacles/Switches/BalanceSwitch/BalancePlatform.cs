using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlatform : BalanceComponent
{
    [SerializeField] uint weight;

    private Dictionary<GameObject, Vector3> objectsOnPlatform;

    void Awake() {
        objectsOnPlatform = new Dictionary<GameObject, Vector3>();
    }

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

        objectsOnPlatform.Add(other.gameObject, other.transform.position - transform.position);
    }

    void OnTriggerStay2D(Collider2D other) {
        objectsOnPlatform[other.gameObject] = other.transform.position - transform.position;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 9) //Other is player or clone
            weight--;

        RequestUpdate();

        objectsOnPlatform.Remove(other.gameObject);
    }

    void LateUpdate() {
        foreach (KeyValuePair<GameObject, Vector3> go in objectsOnPlatform) {
            go.Key.transform.position = transform.position + go.Value;
        }
    }

    public override void Reset() {
        objectsOnPlatform.Clear();
    }
}
