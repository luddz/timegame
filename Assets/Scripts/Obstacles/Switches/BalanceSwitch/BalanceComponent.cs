using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BalanceComponent : MonoBehaviour
{
    private Vector2 moveTo; //Point to move towards smoothly
    private Vector2 balanced; 

    void Start() {
        balanced = transform.localPosition;
        moveTo = balanced;
    }

    void Update() {
        if (transform.parent.GetComponent<BalanceSplitter>() == null) //Only update if the parent is a balance splitter
            return;

        float catchUpSpeed = transform.parent.GetComponent<BalanceSplitter>().GetCatchUpSpeed();

        transform.localPosition = Vector2.Lerp(transform.localPosition, moveTo, catchUpSpeed);
    }

    public void RequestUpdate() {
        if (transform.parent.GetComponent<BalanceSplitter>() != null)
            transform.parent.GetComponent<BalanceSplitter>().RequestUpdate();
        else {
            GetComponent<BalanceSplitter>().UpdateBalance();
        }
    }

    /**
     * Sets position this balanced component should move to using weightmodifier.
     * The weight modifier is equal to the sibling BalanceComponent's weight minus this one's weight.
     * This means that a weight modifier of -1 would move this GameObject to the position where it should
     * be if it weighed 1 unit more than its sibling.
     */
    public void SetMoveTo(int weightModifier) {
        BalanceSplitter parent = transform.parent.GetComponent<BalanceSplitter>();

        Vector2 maxHeight = balanced + new Vector2(0, parent.GetMaxMotion());
        Vector2 minHeight = balanced - new Vector2(0, parent.GetMaxMotion());

        float t = (float) (weightModifier + parent.GetMaxWeightChildren()) /  (2 * parent.GetMaxWeightChildren()); //Finds a value between [0,1] where 0 means the bottom position and 1 means the top

        moveTo = Vector2.Lerp(minHeight, maxHeight, t);
    }

    public abstract uint GetWeight();

    public abstract bool IsFulfilled();

    public abstract void Reset();
}
