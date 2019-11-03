using UnityEngine;
using System.Collections;

/**
 * Class to analyze if an object of a certain layer is adjacent to the object with this script attached.
 * Works best with rectangle shape collision.  Assumes that none of the collision occurs inbetween two bounds.
 */
public class CollisionAnalysis : MonoBehaviour {

    //Points to check relative to player.
    [SerializeField] private Vector2 upRightEdge; //upper bound, rightmost edge
    [SerializeField] private Vector2 upLeftEdge;
    [SerializeField] private Vector2 downRightEdge;
    [SerializeField] private Vector2 downLeftEdge;
    [SerializeField] private Vector2 rightUpEdge;
    [SerializeField] private Vector2 rightDownEdge;
    [SerializeField] private Vector2 leftUpEdge;
    [SerializeField] private Vector2 leftDownEdge;

    //Layers
    [SerializeField] private LayerMask ground;

    /**
	 * Returns whether or not there is ground above.
	 */
    public bool IsGroundUp() {
        Vector2 upRightWorld = (Vector2)transform.position + upRightEdge;
        Vector2 upLeftWorld = (Vector2)transform.position + upLeftEdge;
        return Physics2D.OverlapPoint(upRightWorld, ground) || Physics2D.OverlapPoint(upLeftWorld, ground);
    }

    /**
	 * Returns whether or not there is ground below.
	 */
    public bool IsGroundDown() {
        Vector2 downRightWorld = (Vector2)transform.position + downRightEdge;
        Vector2 downLeftWorld = (Vector2)transform.position + downLeftEdge;
        return Physics2D.OverlapPoint(downRightWorld, ground) || Physics2D.OverlapPoint(downLeftWorld, ground);

    }

    /**
	 * Returns whether or not there is ground to the right.
	 */
    public bool IsGroundRight() {
        Vector2 rightUpWorld = (Vector2)transform.position + rightUpEdge;
        Vector2 rightDownWorld = (Vector2)transform.position + rightDownEdge;
        return Physics2D.OverlapPoint(rightUpWorld, ground) || Physics2D.OverlapPoint(rightDownWorld, ground);
    }

    /**
	 * Returns whether or not there is ground to the left.
	 */
    public bool IsGroundLeft() {
        Vector2 leftUpWorld = (Vector2)transform.position + leftUpEdge;
        Vector2 leftDownWorld = (Vector2)transform.position + leftDownEdge;
        return Physics2D.OverlapPoint(leftUpWorld, ground) || Physics2D.OverlapPoint(leftDownWorld, ground);
    }

}
