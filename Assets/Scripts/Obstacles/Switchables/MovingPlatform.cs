using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : SwitchableSystem
{

    // if set to true loops around the points, moving in a circular pattern through them
    [SerializeField] private bool loopAround;
    [SerializeField] private float speed;

    private List<Vector2> points;
    private int nextPosIndex;
    private bool goingBackwards;

    private Dictionary<GameObject, Vector3> objectsOnPlatform;

    void Awake()
    {
        objectsOnPlatform = new Dictionary<GameObject, Vector3>();
        points = new List<Vector2>();

        for (int i = 0; i < transform.childCount; i++) {
            points.Add(transform.GetChild(i).position);
        }
        ResetSwitchable();
    }

    void Update()
    {
        if (!isOn) {
            return;
        }

        Move();
    }

    private void LateUpdate()
    {
        foreach (KeyValuePair<GameObject, Vector3> go in objectsOnPlatform)
        {
            //Help move the other objects so that they stick to the platform when on it.
            go.Key.transform.position = transform.position + go.Value;
        }
    }


    // moves the platform forwards at speed 'speed' towards nextPos
    private void Move()
    {
        float distanceMovedByPlatform = speed * Time.deltaTime;
        Vector2 nextPos = points[nextPosIndex];

        float distanceBetweenPlatformAndNextPos = Vector2.Distance(transform.position, nextPos);

        // change our destination of movement
        if (distanceMovedByPlatform >= distanceBetweenPlatformAndNextPos)
        {
            transform.position = nextPos;
            ChangeDestination();
        }

        // move towards the current next position
        else {
            transform.position = Vector2.MoveTowards(transform.position, nextPos, distanceMovedByPlatform);
        }
    }

    // Changes the destination of movement
    private void ChangeDestination()
    {
        if (!loopAround && nextPosIndex==0 && goingBackwards) {
            goingBackwards = false;
        }

        nextPosIndex += goingBackwards ? -1 : 1;

        if (nextPosIndex >= points.Count) {

            if (loopAround)
            {
                nextPosIndex = 0;
            }

            else {
                nextPosIndex = points.Count - 2;
                goingBackwards = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        objectsOnPlatform.Add(other.gameObject, other.transform.position-transform.position);
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        objectsOnPlatform[other.gameObject] = other.transform.position - transform.position;   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objectsOnPlatform.Remove(other.gameObject);
    }

    public override void ResetSwitchable()
    {
        transform.position = points[0];
        nextPosIndex = 0;
        objectsOnPlatform.Clear();
    }

    //TODO SFX animations
    protected override void SwitchOff()
    {
    }

    //TODO SFX animations
    protected override void SwitchOn()
    {
    }

}
