using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceSwitch : SwitchSystem
{
    private bool lateStart = true;

    // Update is called once per frame
    void Update()
    {
        if(lateStart) {
            lateStart = false;

            transform.GetChild(0).GetComponent<BalanceSplitter>().UpdateBalance();
        }

        //Check if Balance system is fulfilled
        if (transform.GetChild(0).GetComponent<BalanceSplitter>().IsFulfilled())
            ActivateSwitch();
        else
            DeactivateSwitch();
        
    }

    protected override void ActivateSwitch() {
        if (activated) return; //Already activated

        activated = true;
        foreach (SwitchableSystem s in switchables) {
            s.Switch();
        }

        //TODO add animation and SFX
    }

    protected override void DeactivateSwitch() {
        if (!activated) return; //Already deactivated

        activated = false;
        foreach (SwitchableSystem s in switchables) {
            s.Switch();
        }

        //TODO add animation and SFX
    }

    public override void ResetSwitch() {
        DeactivateSwitch();
    }
}
