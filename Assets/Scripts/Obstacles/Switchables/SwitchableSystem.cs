using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * An abstract class that all game objects that can be switched on or off should inherit.
 * Examples are doors or lasers. This does not include the actual switch itself.
 */
public abstract class SwitchableSystem : MonoBehaviour
{
    [SerializeField]
    protected bool isOn;

    //Switches the switchable to on if it is off or off if it is on.
    public void Switch() {
        isOn = !isOn;
        if (isOn)
            SwitchOn();
        else
            SwitchOff();
    }

    //Switches the switchable to switchTo
    public void SwitchTo(bool switchTo) {
        if (isOn == switchTo) //Do nothing if it is switching to what it already is.
            return;

        isOn = switchTo;
        if (isOn)
            SwitchOn();
        else
            SwitchOff();
    }

    //What happens when we turn on the switch?
    protected abstract void SwitchOn();

    //What happens when we turn off the switch?
    protected abstract void SwitchOff();
}
