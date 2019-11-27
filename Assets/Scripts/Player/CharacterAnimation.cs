using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private float flipDeadZone; //How fast do you have to move to flip horizontally

    //Componenets
    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private CollisionAnalysis analyser;

    //Helping variables
    private bool shooting;
    private bool solid;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        analyser = GetComponent<CollisionAnalysis>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //Flip sprite appropriately
        if(body.velocity.x < -flipDeadZone) {
            sprite.flipX = true;
        }

        if(body.velocity.x > flipDeadZone) {
            sprite.flipX = false;
        }

        //Don't update animations if shooting or solid or dead
        if (shooting || solid)
            return;

        //Idle
        if (analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) < flipDeadZone) {
            anim.Play("playerIdle");
        }
        //Run
        else if(analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) > flipDeadZone) {
            anim.Play("playerRun");
        }
        //Jump
        else if(!analyser.IsGroundDown()) {
            anim.Play("playerJump");
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
        anim.Play("playerSolidify");
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

    public void ResetAnimations() {
        SetSpeed(1.0f);
        ActivateSprite();
        shooting = false;
        solid = false;
    }
}
