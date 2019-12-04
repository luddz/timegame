using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private bool isOverground;
    [SerializeField] private float switchSpeed;

    private float timeElapsed;
    private bool switching;

    private static BackgroundManager instance;

    public static BackgroundManager Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        if(isOverground) {
            SwitchBackgroundByAmount(1.0f);
        } else {
            SwitchBackgroundByAmount(0.0f);
        }
    }

    void Update() {
        if (!switching)
            return;

        timeElapsed += Time.deltaTime;

        float t = timeElapsed / switchSpeed;
        t = Mathf.Clamp(t, 0.0f, 1.0f);

        if (t >= 1.0f)
            switching = false;

        if(isOverground) {
            SwitchBackgroundByAmount(t);
        } else {
            SwitchBackgroundByAmount(1.0f - t);
        }
    }

    public void SetBackground(bool overground) {
        if (overground == isOverground) return;
        timeElapsed = 0.0f;
        switching = true;
        isOverground = overground;
    }

    private void SwitchBackgroundByAmount(float t) {
        ApplySwitch(transform.GetChild(0), t);
        ApplySwitch(transform.GetChild(1), 1 - t);
    }

    private void ApplySwitch(Transform background, float t) {
        foreach (Transform child in background) {
            if(child.GetComponent<SpriteRenderer> () != null) {
                Color temp = child.GetComponent<SpriteRenderer>().color;
                temp.a = t;
                child.GetComponent<SpriteRenderer>().color = temp;
            }
            ApplySwitch(child, t);
        }
    }

    public bool GetIsOverground() {
        return isOverground;
    }
}
