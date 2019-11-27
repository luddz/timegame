using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    [SerializeField] private Color color;
    [SerializeField] private float width;

    private LineRenderer line;

    public void SetUpLaser (Vector3 startPoint, Vector3 endPoint) {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        line = GetComponent<LineRenderer>();

        DrawLaser();
    }

    /**
     * Draws a Line. (Somewhat stolen from this thread: https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html)
     */
    private void DrawLaser() {
        line.material.color = color;
        line.startColor = color;
        line.endColor = color;
        line.startWidth = width;
        line.endWidth = width;
        line.SetPosition(0, startPoint);
        line.SetPosition(1, endPoint);
    }
}
