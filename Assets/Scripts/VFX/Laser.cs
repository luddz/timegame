using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    private GameObject startParticles;
    private GameObject endParticles;
    private Color color;

    private LineRenderer line;

    public void SetUpLaser (Vector3 startPoint, Vector3 endPoint, GameObject startParticles, GameObject endParticles, Color color, bool hit) {
        this.startPoint = startPoint;
        this.startParticles = startParticles;
        this.endParticles = endParticles;
        this.color = color;

        this.startParticles.transform.position = startPoint;

        UpdateLaser(this.endPoint, hit);
    }

    public void UpdateLaser (Vector3 endPoint, bool hit) {
        this.endPoint = endPoint;

    }
}
