using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    [SerializeField] private bool overground; //if true switch to overground background, if false switch to underground

    void OnTriggerEnter2D(Collider2D other) {
        if (PlayerManager.Instance.IsPlayer(other.gameObject)) {
            BackgroundManager.Instance.SetBackground(overground);
        }
    }
}
