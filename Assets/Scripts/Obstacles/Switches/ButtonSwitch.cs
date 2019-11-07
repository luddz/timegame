using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : SwitchSystem
{
    [SerializeField]
    private int playersRequired = 1;

    private int currentPlayers; //How many players/clones are currently pressing the switch

    // Start is called before the first frame update
    void Start()
    {
        currentPlayers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ActivateSwitch() {
        activated = true;
        switchable.Switch();
        //TODO add animation and SFX
    }

    protected override void DeactivateSwitch() {
        activated = false;
        switchable.Switch();
        //TODO add animation and SFX
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "GameController")
            currentPlayers++;

        if (currentPlayers >= playersRequired && !activated)
            ActivateSwitch();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "GameController")
            currentPlayers--;

        if (currentPlayers < playersRequired && activated && !permanent)
            DeactivateSwitch();
    }
}
