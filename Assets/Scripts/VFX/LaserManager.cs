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
     * Creates a new laser that has a set lifespan
     */
    public void NewLaser(Vector3 start, Vector3 end, Color color, bool hit, float duration) {
        
    }

    /**
     * Creates a new laser that is persistant
     */
    public int NewLaser(Vector3 start, Vector3 end, Color color, bool hit) {
        return lasers.Count - 1;
    }
}
