using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : SwitchableSystem
{
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject laser;
    [Space]
    [SerializeField] private bool steadyFire; //Is the turret shooting a constant laser?
    [SerializeField] private float shotDelay; //Time between shots
    [SerializeField] private float shotDuration; //How long does a shot last?

    private float timeElapsed;
    
    // Start is called before the first frame update
    void Awake() {
        laser = Instantiate(laser);
        timeElapsed = 0;
        //If laser is on as default
        laser.SetActive(isOn);
    }

    // Update is called once per frame
    void Update() {
        if (!isOn)
            return;
        timeElapsed += Time.deltaTime;
        if (steadyFire || (timeElapsed > shotDelay && timeElapsed <= shotDelay + shotDuration)) {
            laser.SetActive(true);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxDistance, LayerMask.GetMask("Character") | LayerMask.GetMask("Ground"));
            Vector2 end;
            if (hit.collider != null) {
                end = hit.point;
                if (hit.collider.gameObject.layer == 9) {
                    hit.collider.gameObject.GetComponent<CharacterMovement>().Die();
                }
            } else {
                end = transform.position + transform.right * maxDistance;
            }

            //Draw laser
            laser.GetComponent<Laser>().SetUpLaser(transform.position, end, hit.collider != null);
        }
        if(!steadyFire) {
            if (timeElapsed < shotDelay)
                laser.SetActive(false);
            if (timeElapsed > shotDelay + shotDuration)
                timeElapsed = 0;
        }
    }

    // Open door
    protected override void SwitchOn() {
        laser.SetActive(true); //TODO add animations and SFX
    }

    // Close door
    protected override void SwitchOff() {
        laser.SetActive(false); //TODO add animations and SFX
    }

    public override void ResetSwitchable() {
        timeElapsed = 0;
    }
}
