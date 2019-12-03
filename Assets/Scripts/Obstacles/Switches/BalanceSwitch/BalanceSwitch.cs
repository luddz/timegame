﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceSwitch : SwitchSystem
{
    private BalanceSplitter splitter;
    private bool init = true;
    
    void Awake() {
        splitter = transform.GetChild(0).GetComponent<BalanceSplitter>();
    }

    // Update is called once per frame
    void Update() {
        if(init) {
            splitter.UpdateBalance();
            init = false;
        }

        //Check if Balance system is fulfilled
        if (splitter.IsFulfilled())
            ActivateSwitch();
        else if (!permanent)
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
        splitter.Reset();
    }
}