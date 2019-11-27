using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotSwitch : MonoBehaviour
{
    [SerializeField] private bool playerPivot;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Transform newPivot = (playerPivot) ? other.transform : transform.parent;
            CameraManager.Instance.SetPivot(newPivot);
        }
    }
}
