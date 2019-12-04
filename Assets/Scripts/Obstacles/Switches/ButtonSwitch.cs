using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : SwitchSystem
{
    [SerializeField]
    private int playersRequired = 1;

    private int currentPlayers; //How many players/clones are currently pressing the switch

    // Start is called before the first frame update
    void Awake()
    {
        currentPlayers = 0;
	if(activated)
	    GetComponent<Animator>().Play("pressed");
	else
	    GetComponent<Animator>().Play("unpressed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ActivateSwitch() {
        if (activated) return; //Already activated

        activated = true;
        foreach(SwitchableSystem s in switchables) {
            s.Switch();
        }

        //TODO add animation and SFX
        GetComponent<Animator>().Play("pressed");
        AudioManager.Instance.Play("Button", transform.position);
    }

    protected override void DeactivateSwitch() {
        if (!activated) return; //Already deactivated

        activated = false;
        foreach (SwitchableSystem s in switchables) {
            s.Switch();
        }

        //TODO add animation and SFX
        GetComponent<Animator>().Play("unpressed");
        AudioManager.Instance.Play("Button", transform.position);
    }

    public override void ResetSwitch() {
        DeactivateSwitch();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "GameController")
            currentPlayers++;

        if (currentPlayers >= playersRequired)
            ActivateSwitch();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "GameController")
            currentPlayers--;

        if (currentPlayers < playersRequired && !permanent)
            DeactivateSwitch();
    }
}
