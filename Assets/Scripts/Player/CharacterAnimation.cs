using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private float flipDeadZone; //How fast do you have to move to flip horizontally

    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.x < -flipDeadZone) {
            sprite.flipX = true;
        }

        if(body.velocity.x > flipDeadZone) {
            sprite.flipX = false;
        }
    }
}
