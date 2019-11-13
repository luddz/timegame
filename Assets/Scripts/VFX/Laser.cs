using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject particleSystemObject;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private GameObject startParticles;
    private GameObject endParticles;
    private Color color;

    private LineRenderer line;

    public void SetUpLaser (Vector3 startPoint, Vector3 endPoint, Color color, bool hit) {
        this.startPoint = startPoint;
        this.startParticles = Instantiate(particleSystemObject); //TODO instantiate with rotation and position
        this.endParticles = Instantiate(particleSystemObject); //TODO instantiate with rotation and position
        this.color = color;

        this.startParticles.transform.position = startPoint;
        line = GetComponent<LineRenderer>();

        UpdateLaser(this.endPoint, hit);
    }

    public void UpdateLaser (Vector3 endPoint, bool hit) {
        this.endPoint = endPoint;
        endParticles.transform.position = endPoint;
        if (hit)
            endParticles.GetComponent<ParticleSystem>().Play();
        else
            endParticles.GetComponent<ParticleSystem>().Stop(false, ParticleSystemStopBehavior.StopEmitting);

        DrawLaser();
    }

    /**
     * Draws a Line. (Somewhat stolen from this thread: https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html)
     */
    private void DrawLaser() {
        line.startColor = color;
        line.endColor = color;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
    }
}
