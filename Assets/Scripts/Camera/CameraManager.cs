﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    private static CameraManager instance;

    [SerializeField] private Transform player;
    [SerializeField] private Transform roomPivot;
    [SerializeField] private float catchUpSpeed; //t in the Lerp

    public static CameraManager Instance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Set up desired position
        Vector3 desiredPos = (player.position + roomPivot.position) / 2;
        desiredPos.z = transform.position.z;

        //Move Camera
        transform.position = Vector3.Lerp(transform.position, desiredPos, catchUpSpeed);
    }

    public void SetPivot(Transform pivot) {
        roomPivot = pivot;
    }
}
