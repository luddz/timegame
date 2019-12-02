using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private float flipDeadZone; //How fast do you have to move to flip horizontally
    [SerializeField] private float minArcVelocity; //How slow do you have to be going when jumping to "switch" to falling animation

    //Componenets
    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private CollisionAnalysis analyser;

    //Helping variables
    private bool shooting;
    private bool solid;
    private bool jumpingUp;
    private bool dying;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        analyser = GetComponent<CollisionAnalysis>();
        color = sprite.color;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //To correct for late dying
        if(dying && !anim.GetCurrentAnimatorStateInfo(0).IsName("playerDie")) {
            Debug.Log("Here");
        }

        //Flip sprite appropriately
        if(body.velocity.x < -flipDeadZone) {
            sprite.flipX = true;
        }

        if(body.velocity.x > flipDeadZone) {
            sprite.flipX = false;
        }

        //Don't update animations if shooting or solid or dead
        if (shooting || solid || dying)
            return;

        //Idle
        if (!jumpingUp && analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) < flipDeadZone) {
            anim.Play("playerIdle");
        }
        //Run
        else if(!jumpingUp && analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) > flipDeadZone) {
            anim.Play("playerRun");
            anim.SetFloat("RunSpeed", Mathf.Abs(body.velocity.x) / GetComponent<CharacterMovement> ().GetRunSpeed());
        }
        //Jump
        else if(!analyser.IsGroundDown() && Mathf.Abs(body.velocity.y) < minArcVelocity) {
            anim.Play("playerJumpSwitch");
            jumpingUp = false;
        } 
        //Clear Jumping up
        else if(!analyser.IsGroundDown()) {
            jumpingUp = false;
        }
    }

    public void StartShoot() {
        shooting = true;
        anim.Play("playerShoot");
    }

    public void StopShoot() {
        shooting = false;
    }

    public void StartSolid() {
        solid = true;
        sprite.color = Color.gray;
    }

    public void StartJump() {
        anim.Play("playerJumpUp");
        jumpingUp = true;
    }

    public void StartJumpStay() {
        anim.Play("playerJumpUpStay");
    }

    public void StartFall() {
        anim.Play("playerJumpDown");
        jumpingUp = false;
    }

    public void StartDie() {
        anim.Play("playerDie");
        dying = true;
    }

    public void SetSpeed(float speed) {
        GetComponent<Animator>().speed = speed;
    }
    
    public void DeactivateSprite() {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    public void ActivateSprite() {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void TurnGray(float t) {
        sprite.color = Color.Lerp(color, Color.gray, t);
    }

    public void ResetAnimations() {
        SetSpeed(1.0f);
        ActivateSprite();
        GetComponent<Animator>().Rebind();
        if (sprite != null)
            sprite.color = color;
        shooting = false;
        solid = false;
        dying = false;
    }
}
