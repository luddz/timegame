using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : SwitchableSystem
{
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject laser;
    
    // Start is called before the first frame update
    void Start() {
        laser = Instantiate(laser);
        //If door open as default
        if (isOn)
            laser.SetActive(true); //TODO change sprite etc, not deactivate object.
        else
            laser.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (!isOn)
            return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxDistance, LayerMask.GetMask("Character") | LayerMask.GetMask("Ground"));
        Vector2 end;
        if(hit.collider != null) {
            end = hit.point;
            if(hit.collider.gameObject.layer == 9) {
                hit.collider.gameObject.GetComponent<CharacterMovement>().Die();
            }
        } else {
            end = transform.position + transform.right * maxDistance;
        }

        //Draw laser
        laser.GetComponent<Laser>().SetUpLaser(transform.position, end, hit.collider != null);
    }

    // Open door
    protected override void SwitchOn() {
        laser.SetActive(true); //TODO add animations and SFX
    }

    // Close door
    protected override void SwitchOff() {
        laser.SetActive(false); //TODO add animations and SFX
    }
}
