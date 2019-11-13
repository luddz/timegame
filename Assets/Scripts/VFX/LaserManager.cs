using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    private static LaserManager instance;

    public static LaserManager Instance { get { return instance; } }

    private List<Laser> lasers;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Draws a Line. (Somewhat stolen from this thread: https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html)
     */
    private void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.05f) {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.02f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    public void NewLaser(Vector3 start, Vector3 end, Color color, bool hit, float duration = 0.05f) {

    }
}
