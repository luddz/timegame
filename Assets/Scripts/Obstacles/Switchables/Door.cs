using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : SwitchableSystem
{
    // Start is called before the first frame update
    void Awake()
    {
        //If door open as default
        if (isOn)
            gameObject.SetActive(false); //TODO change sprite etc, not deactivate object.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Open door
    protected override void SwitchOn() {
        gameObject.SetActive(false); //TODO add animations and SFX
    }

    // Close door
    protected override void SwitchOff() {
        gameObject.SetActive(true); //TODO add animations and SFX
    }

    public override void ResetSwitchable() {
        //Note that this does nothing, Unity just has a problem with building sometimes if a method is left empty.
        int temp = 0; 
        temp++;
        if (temp > 0)
            return;
    }
}
