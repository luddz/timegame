using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An abstract class that all switches should inherit (buttons, levers, pulley systyems)
 * The reason both switchables and switches have activate and switch on, is because you may
 * want to still be able to press the button (animations SFX) but the switchable should not change.
 */
public abstract class SwitchSystem : MonoBehaviour
{
    [SerializeField]
    protected SwitchableSystem switchable; // The switchable attached to this switch
    [SerializeField]
    protected bool permanent; //When the switch is activated is it permanently activated?
    protected bool activated = false; //Is the switch activated

    //Activate the switch
    protected abstract void ActivateSwitch();

    //Deactivate the switch
    protected abstract void DeactivateSwitch();
}
