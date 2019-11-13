using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : SwitchableSystem
{
    [SerializeField] private float maxDistance;
    
    // Start is called before the first frame update
    void Start() {
        //If door open as default
        if (isOn)
            gameObject.SetActive(false); //TODO change sprite etc, not deactivate object.
    }

    // Update is called once per frame
    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxDistance, LayerMask.GetMask("Character") | LayerMask.GetMask("Ground"));
        Vector2 end;
        if(hit.collider != null) {
            end = hit.point;
            if(hit.collider.gameObject.layer == 9) {
                hit.collider.gameObject.GetComponent<CharacterMovement>().Die();
            } else {
                end = transform.position + transform.right * maxDistance;
            }
        }

        //Draw laser
    }

    // Open door
    protected override void SwitchOn() {
        gameObject.SetActive(false); //TODO add animations and SFX
    }

    // Close door
    protected override void SwitchOff() {
        gameObject.SetActive(true); //TODO add animations and SFX
    }
}
