using UnityEngine;

public class AirVent : SwitchableSystem
{

    [SerializeField] float windPressure; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
           Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();

           float dist = Vector2.Distance(other.gameObject.transform.position, transform.position);
           float height= GetComponent<BoxCollider2D>().size.y;
           float multiplier = 1 /dist;

            Vector2 force = windPressure * transform.up * multiplier;

            playerBody.velocity = force + playerBody.velocity;
        }
    }

    // No necessary action
    public override void ResetSwitchable()
    {
       
    }

    protected override void SwitchOff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    protected override void SwitchOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
