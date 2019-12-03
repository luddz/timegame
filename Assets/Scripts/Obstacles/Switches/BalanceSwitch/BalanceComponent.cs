using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BalanceComponent : MonoBehaviour
{
    private Vector2 moveTo; //Point to move towards smoothly
    private Vector2 moveFrom;
    protected Vector2 balanced;
    protected GameObject chain;

    private float timeElapsed;

    void Start() {
        balanced = transform.localPosition;
        moveTo = balanced;
        moveFrom = balanced;

        Vector3 chainPos = -transform.localPosition / 2;
        chain.transform.localPosition = new Vector3(0, chainPos.y, 0);
        chain.GetComponent<SpriteRenderer>().size = new Vector2(1, Mathf.Abs(transform.localPosition.y));
    }

    void Update() {
        if (transform.parent.GetComponent<BalanceSplitter>() == null) //Only update if the parent is a balance splitter
            return;

        if(transform.localPosition.y != moveTo.y) {
            float catchUpSpeed = transform.parent.GetComponent<BalanceSplitter>().GetCatchUpSpeed();
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / catchUpSpeed;
            if (t > 1.0f)
                t = 1.0f;

            transform.localPosition = Vector2.Lerp(moveFrom, moveTo, 1 - Mathf.Pow(1-t, 3));

            Vector3 chainPos = -transform.localPosition / 2;
            chain.transform.localPosition = new Vector3(0, chainPos.y, 0);
            chain.GetComponent<SpriteRenderer>().size = new Vector2(1, Mathf.Abs(transform.localPosition.y));
        }
        
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

        moveFrom = transform.localPosition;
        moveTo = Vector2.Lerp(minHeight, maxHeight, t);
        timeElapsed = 0;
    }

    public abstract uint GetWeight();

    public abstract bool IsFulfilled();

    public abstract void Reset();
}
