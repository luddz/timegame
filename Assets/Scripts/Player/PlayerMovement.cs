using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Editable Movement Constants
    [SerializeField] private float maxHorizontalVelocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float deceleration;
    [SerializeField] private float terminalVelocity; //Vertical max speed
    [SerializeField] private int maxJumpDelay; //Amount of updates after falling off of a ledge where you can still jump

    //Movement Variables
    private int jumpDelay;

    //Components
    private Rigidbody2D body;
    private CollisionAnalysis analyser;
    private ControlManager controller;

    // Start is called before the first frame update
    void Start()
    {
        //Component Set up
        body = GetComponent<Rigidbody2D>();
        analyser = GetComponent<CollisionAnalysis>();
        controller = GetComponent<ControlManager>();
    }

    void FixedUpdate()
    {
        //Terminal velocity
        if (body.velocity.y < -terminalVelocity)
            body.velocity = new Vector2(body.velocity.x, -terminalVelocity);

        //Walking
        float horizontalV = maxHorizontalVelocity * controller.Horizontal();
        if (Mathf.Abs(body.velocity.x) > Mathf.Abs(horizontalV)) { //Deceleration
            if (body.velocity.x > 0) {
                body.velocity -= new Vector2(deceleration * Time.deltaTime, 0);
                if (body.velocity.x < horizontalV)
                    body.velocity = new Vector2(horizontalV, body.velocity.y);
            } else if (body.velocity.x < 0) {
                body.velocity += new Vector2(deceleration * Time.deltaTime, 0);
                if (body.velocity.x > horizontalV)
                    body.velocity = new Vector2(horizontalV, body.velocity.y);
            }
        } else if (horizontalV != 0) { //Walk
            body.velocity = new Vector2(horizontalV, body.velocity.y);
        }

        //Jumping
        if (controller.JumpButtonDown() && jumpDelay < maxJumpDelay) {
            jumpDelay = maxJumpDelay;
            body.velocity = new Vector2(body.velocity.x, jumpVelocity);
        }
        //Height controlled by button press duration.
        if (controller.JumpButtonUp() && !analyser.IsGroundDown() && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2); //Can be changed from 2, it's just that 2 worked pretty nicely.

        //Jumping after fall
        if (analyser.IsGroundDown() && body.velocity.y == 0)
            jumpDelay = 0;
        else
            jumpDelay += jumpDelay < maxJumpDelay ? 1 : 0;
    }
}
