using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private float flipDeadZone; //How fast do you have to move to flip horizontally

    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private CollisionAnalysis analyser;
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

        //Idle
        if(analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) < flipDeadZone) {
            anim.SetTrigger("idle");
        }
        //Run
        else if(analyser.IsGroundDown() && Mathf.Abs(body.velocity.x) > flipDeadZone) {
            anim.SetTrigger("run");
        }
        //Jump
        else if(!analyser.IsGroundDown()) {
            anim.SetTrigger("jump");
        }
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
}
