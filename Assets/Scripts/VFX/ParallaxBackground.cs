using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxAmount;

    private GameObject camera;
    private float length;
    private float startPosition;

    // Start is called before the first frame update
    void Start()
    {
        camera = CameraManager.Instance.gameObject;
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = camera.transform.position.x * (1 - parallaxAmount);
        float distance = camera.transform.position.x * parallaxAmount;

        transform.position = new Vector3(startPosition + distance, camera.transform.position.y, transform.position.z);

        if (temp > startPosition + length)
            startPosition += length;
        else if (temp < startPosition - length)
            startPosition -= length;
    }
}
