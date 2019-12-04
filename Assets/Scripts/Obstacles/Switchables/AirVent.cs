using UnityEngine;

/** Air vent/geyser that causes the player to move along transform.up of the air vent
    To use set terminal velocity and wind pressure and use the collision box to set the area where the air blows */
public class AirVent : SwitchableSystem
{
    // controls how strong the air that blows is 
    [SerializeField] float windPressure;
    // when the player's velocity exceeds this value, then the player is unaffected by wind blowing out of AirVent
    [SerializeField] float terminalVelocity;
    private ParticleSystem particles;

    void Awake() {
        GetComponent<BoxCollider2D>().enabled = isOn;
        particles = GetComponent<ParticleSystem>();
        if(!isOn) particles.Pause();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {

            Rigidbody2D otherBody = other.gameObject.GetComponent<Rigidbody2D>();


            if (Mathf.Abs(otherBody.velocity.magnitude) >= terminalVelocity)
            {
                // do nothing! 
            }

            else
            {
               
                float airVentWidth = GetComponent<BoxCollider2D>().size.x;
                float airVentHeight = GetComponent<BoxCollider2D>().size.y;

                // get the height of the object above the player by calculating distance from bottom of air vent
                Vector2 linePt1 = transform.position;
                Vector2 linePt2 = transform.position + transform.right.normalized * airVentWidth;
                Vector2 point = other.gameObject.transform.position;
                float heightAboveAirVent = distanceBetweenLineAndPoint(linePt1, linePt2, point);

                // percentage representation of height with respect to height of the air vent
                float h = (heightAboveAirVent / airVentHeight);
                Vector2 upVector = new Vector2(transform.up.x, transform.up.y);

                // Set the velocity according to a function that takes into account height above the geyser
               
                otherBody.velocity = otherBody.velocity + upVector * weightFunction(h) * windPressure;
            }

        }
    }

    // No necessary action
    public override void ResetSwitchable()
    {
       
    }

    // Returns a weight function that has to take in a value between 0 and 1, and then returns a value 0-1
    private float weightFunction(float x) {

        // f(x) = (x-2)^(-2*k)-2^(-2*k)*(1-x) with k=3 is a good weight funtion with expontential properties, kinda like exponential decay!
        // invert it by using (1-x) instead of 'x'

        // exponential increase from 0 to 1 giving values 0-1;
        float weight = Mathf.Pow(((1-x) - 2), (-2 * 3)) - Mathf.Pow(2, (-2 * 3)) * (1 - (1-x));

        if (weight >= 1) { return 1; }
        if (weight <= 0) { return 0; }

        return weight;
    }


    // returns the minimum distance form line segment (p0->p1) to point p in 2D space
    private float distanceBetweenLineAndPoint(Vector2 p0, Vector2 p1, Vector2 p) {

        Vector3 vL = new Vector3(p1.x - p0.y, p1.x - p0.y, 0); 
        Vector2 w = new Vector3(p.x - p0.y, p.x - p0.y, 0);

        float x0 = p0.x;
        float y0 = p0.y;

        float x = p.x;
        float y = p.y;

        float x1 = p1.x;
        float y1 = p1.y;


        float dist=( (y0 - y1)*x +(x1 - x0)*y +(x0*y1 - x1*y0) ) /  ( Mathf.Sqrt(Mathf.Pow(x1 - x0, 2)+Mathf.Pow(y1 - y0, 2)) );

        return dist;
    }

    protected override void SwitchOff()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        particles.Stop();
    }

    protected override void SwitchOn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        particles.Play();
    }

}
