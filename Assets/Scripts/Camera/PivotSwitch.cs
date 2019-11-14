using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotSwitch : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            CameraManager.Instance.SetPivot(transform.parent);
        }
    }
}
