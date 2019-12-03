using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlatform : BalanceComponent
{
    [SerializeField] uint weight;

    private Dictionary<GameObject, Vector3> objectsOnPlatform; //This is so that objects on the platform move with the platform.

    void Awake() {
        objectsOnPlatform = new Dictionary<GameObject, Vector3>();
        chain = transform.GetChild(0).gameObject;
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
        foreach (KeyValuePair<GameObject, Vector3> go in objectsOnPlatform) { //Help move the other objects so that they stick to the platform when on it.
            go.Key.transform.position = transform.position + go.Value;
        }
    }

    public override void Reset() {
        objectsOnPlatform.Clear();
        transform.localPosition = balanced;
    }
}
