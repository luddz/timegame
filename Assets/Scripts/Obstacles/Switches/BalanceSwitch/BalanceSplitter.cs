using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceSplitter : BalanceComponent
{
    private BalanceComponent left; //Left scale
    private BalanceComponent right; //Right scale

    [SerializeField] private uint maxWeightChildren; //The max weight a child balancecomponent can bare before it stops moving.
    [SerializeField] private float maxMotion; //max distance in y-direction that the children objects can move from a balanced position
    [SerializeField] private float catchUpSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        left = transform.GetChild(0).GetComponent<BalanceComponent> ();
        right = transform.GetChild(1).GetComponent<BalanceComponent> ();

        transform.GetChild(2).transform.localPosition = new Vector3(left.transform.localPosition.x, 0, 0);
        transform.GetChild(4).transform.localPosition = new Vector3(left.transform.localPosition.x / 2, 0, 0);
        transform.GetChild(4).GetComponent<SpriteRenderer>().size = new Vector2(Mathf.Abs(left.transform.localPosition.x), 1);

        transform.GetChild(3).transform.localPosition = new Vector3(right.transform.localPosition.x, 0, 0);
        transform.GetChild(5).transform.localPosition = new Vector3(right.transform.localPosition.x / 2, 0, 0);
        transform.GetChild(5).GetComponent<SpriteRenderer>().size = new Vector2(Mathf.Abs(right.transform.localPosition.x), 1);

        chain = transform.GetChild(6).gameObject;

        if (IsFulfilled()) GetComponent<Animator>().Play("active");
        else GetComponent<Animator>().Play("deactive");
    }


    public void UpdateBalance() {
        int leftWeightModifier = Mathf.Clamp((int)(right.GetWeight() - left.GetWeight()), (int)-maxWeightChildren, (int)maxWeightChildren);
        int rightWeightModifier = Mathf.Clamp((int)(left.GetWeight() - right.GetWeight()), (int)-maxWeightChildren, (int)maxWeightChildren);

        left.SetMoveTo(leftWeightModifier);
        right.SetMoveTo(rightWeightModifier);

        //Update Children
        if (left.GetComponent<BalanceSplitter> () != null) //Only update the child if it is a balance splitter
            left.GetComponent<BalanceSplitter>().UpdateBalance();
        if (right.GetComponent<BalanceSplitter>() != null) //Only update the child if it is a balance splitter
            right.GetComponent<BalanceSplitter>().UpdateBalance();

        if (IsFulfilled()) GetComponent<Animator>().Play("active");
        else GetComponent<Animator>().Play("deactive");
    }

    public uint GetMaxWeightChildren() {
        return maxWeightChildren;
    }

    public float GetMaxMotion() {
        return maxMotion;
    }

    public float GetCatchUpSpeed() {
        return catchUpSpeed;
    }

    public override uint GetWeight() {
        return left.GetWeight() + right.GetWeight();
    }

    //Set fulfilled if they are equally balanced and children systems are equally balanced
    public override bool IsFulfilled() {
        return left.GetWeight() == right.GetWeight() && left.IsFulfilled() && right.IsFulfilled();
    }

    public override void Reset() {
        left.Reset();
        right.Reset();

        transform.localPosition = balanced;
    }
}
