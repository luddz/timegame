using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Editable Movement Constants
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float maxHorizontalVelocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float terminalVelocity; //Vertical max speed
    [SerializeField] private int maxJumpDelay; //Amount of updates after falling off of a ledge where you can still jump
    [SerializeField] private float shotDistance; //Distance that you can shoot
    [SerializeField] private float shotOffset; //How far from the center of the player does the shot emerge from
    [Space]
    [SerializeField] private GameObject laser;
    [SerializeField] private float laserDuration;
    [Space]
    [SerializeField] private float solidifyDelay;

    //Movement Variables
    private int jumpDelay;
    private bool facingRight = true; //Is the player facing right
    private float timeSinceSolidify = 0.0f;
    private bool solidifying;

    //Components
    private Rigidbody2D body;
    private CollisionAnalysis analyser;
    private ControlManager controller;
    private CharacterAnimation anim;

    // Start is called before the first frame update
    void Start() {
        //Component Set up
        body = GetComponent<Rigidbody2D>();
        analyser = GetComponent<CollisionAnalysis>();
        controller = GetComponent<ControlManager>();
        anim = GetComponent<CharacterAnimation>();
    }

    void Update() {
        // player presses reset time button
        if (PlayerManager.Instance.IsPlayer(gameObject) && controller.ResetButtonUp()) {
            TimeTravelManager.Instance.ResetTime(true);
        }

        //If solid or dead then stop moving.
        if(gameObject.layer != 9) {
            return;
        }

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
        } else if (Mathf.Abs(body.velocity.x) < Mathf.Abs(horizontalV)) { //Walk
            if (horizontalV > 0) {
                body.velocity += new Vector2(acceleration * Time.deltaTime, 0);
                if (body.velocity.x > horizontalV)
                    body.velocity = new Vector2(horizontalV, body.velocity.y);
            } else if (horizontalV < 0) {
                body.velocity -= new Vector2(acceleration * Time.deltaTime, 0);
                if (body.velocity.x < horizontalV)
                    body.velocity = new Vector2(horizontalV, body.velocity.y);
            }
        }

        //Set facing variable
        if(body.velocity.x > 0) {
            facingRight = true;
        } else if(body.velocity.x < 0) {
            facingRight = false;
        }

        //Jumping
        if (controller.JumpButtonDown() && jumpDelay < maxJumpDelay) {
            //Play SFX 
            if (PlayerManager.Instance.IsPlayer(gameObject))
                AudioManager.Instance.Play("playerJump");
            else
                AudioManager.Instance.PlayCloneSound("playerJump");

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

        //Solidifying
        if (solidifying) {
            timeSinceSolidify += Time.deltaTime;
            float t = timeSinceSolidify / solidifyDelay;
            //Become solid
            if(t >= 1.0f) {
                gameObject.layer = 8;
                body.constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;
                anim.SetSpeed(0.0f);
                //TODO change sprite and play sfx
                return;
            }
            body.velocity *= 1.0f - t;
            anim.SetSpeed(1.0f - t);
            //Changes that only happen when player solidifies
            if(PlayerManager.Instance.IsPlayer(gameObject)) {
                AudioManager.Instance.SetThemePitch(1.0f - t);
            }
            
        }

        //Initiate Solidifying
        if (controller.SolidifyButtonDown()) {
            solidifying = true;
        }

        //Clearing Checkpoint
        if (PlayerManager.Instance.IsPlayer(gameObject) && analyser.IsCheckpointOverlapping() && controller.ClearButtonDown()) {
            CheckpointManager.Instance.ClearCheckpoint();
            TimeTravelManager.Instance.ResetTime(false);
        }

        //Shooting
        if(controller.ShootButtonDown()) {
            Vector2 forwardVector = (facingRight) ? Vector2.right : Vector2.left;
            Vector2 origin = (Vector2)transform.position + forwardVector * shotOffset;
            RaycastHit2D hit = Physics2D.Raycast(origin, forwardVector, shotDistance, LayerMask.GetMask("Character") | LayerMask.GetMask("Ground")); //Raycast forward
            if (hit.collider != null) {
                if (hit.collider.gameObject.layer == 9 && hit.collider.gameObject.tag != "Player") {
                    hit.collider.gameObject.SetActive(false);
                }
                GameObject currentLaser = Instantiate(laser);
                currentLaser.GetComponent<Laser>().SetUpLaser(origin, hit.point, true);
                Destroy(currentLaser, laserDuration);
            } else {
                GameObject currentLaser = Instantiate(laser);
                currentLaser.GetComponent<Laser>().SetUpLaser(origin, origin + forwardVector * shotDistance, false);
                Destroy(currentLaser, laserDuration);
            }
            //Play SFX
            if (PlayerManager.Instance.IsPlayer(gameObject))
               AudioManager.Instance.Play("LaserShoot");
            else
                AudioManager.Instance.PlayCloneSound("LaserShoot");
        }
    }

    public Vector3 GetStartPosition() {
        return startPosition;
    }

    /**
     * Sets a new start position
     */
    public void SetStartPosition(Vector3 newStartPosition, Checkpoint newCheckpoint) {
        TimeTravelManager.Instance.ResetTime(true); // Reset time before you set a new start position and creates a clone from the last start point
        startPosition = newStartPosition; //Set new start position
        CheckpointManager.Instance.SetActiveCheckpoint(newCheckpoint); //Set new checkpoint
        TimeTravelManager.Instance.ResetTime(false); // Reset time using the new startPosition
    }

    /**
     * Sets a new start position without updating checkpoint
     */
     public void SetStartPosition(Vector3 newStartPosition) {
        startPosition = newStartPosition; //Set new start position
    }

    public void ResetCharacter() {
        GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
        gameObject.layer = 9; //reset layer
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; //reset constraints
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        facingRight = true;
        GetComponent<PolygonCollider2D>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
        AudioManager.Instance.SetThemePitch(1.0f);
        solidifying = false;
        timeSinceSolidify = 0.0f;
        GetComponent<CharacterAnimation>().SetSpeed(1.0f);
        gameObject.SetActive(true);
    }

    public void Die() {
        if (PlayerManager.Instance.IsPlayer(gameObject))
        {
            AudioManager.Instance.Play("LaserWall");
            TimeTravelManager.Instance.ResetTime(false); //Maybe also clear the checkpoint as punishment?
        }
        else
        {
            AudioManager.Instance.PlayCloneSound("LaserWall");
            gameObject.SetActive(false); //Deactivating the player can mess with the movement recorder.
        }
    }
}
