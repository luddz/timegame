using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : SwitchableSystem
{
    [SerializeField] private float maxDistance; //The laser will go this far regardless of what it hits
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
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Character"));
            Physics2D.Raycast(transform.position, transform.right, filter, hits, maxDistance);
            foreach (RaycastHit2D hit in hits) {
                hit.collider.gameObject.GetComponent<CharacterMovement>().Die();
            }

            //Draw laser
            Vector2 end = transform.position + transform.right * maxDistance;
            laser.GetComponent<Laser>().SetUpLaser(transform.position, end);
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
