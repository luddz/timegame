using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    [SerializeField] private Vector2 insideUpRight; //Inside the player
    [SerializeField] private Vector2 insideUpLeft;
    [SerializeField] private Vector2 insideDownRight;
    [SerializeField] private Vector2 insideDownLeft;

    //Layers
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask character;
    [SerializeField] private LayerMask checkpoint;
    [SerializeField] private LayerMask vent;

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

    /**
 * Returns whether or not there is vent above.
 */
    public bool IsVentUp() {
        Vector2 upRightWorld = (Vector2)transform.position + upRightEdge;
        Vector2 upLeftWorld = (Vector2)transform.position + upLeftEdge;
        return Physics2D.OverlapPoint(upRightWorld, vent) || Physics2D.OverlapPoint(upLeftWorld, vent);
    }

    /**
	 * Returns whether or not there is vent below.
	 */
    public bool IsVentDown() {
        Vector2 downRightWorld = (Vector2)transform.position + downRightEdge;
        Vector2 downLeftWorld = (Vector2)transform.position + downLeftEdge;
        return Physics2D.OverlapPoint(downRightWorld, vent) || Physics2D.OverlapPoint(downLeftWorld, vent);

    }

    /**
	 * Returns whether or not there is vent to the right.
	 */
    public bool IsVentRight() {
        Vector2 rightUpWorld = (Vector2)transform.position + rightUpEdge;
        Vector2 rightDownWorld = (Vector2)transform.position + rightDownEdge;
        return Physics2D.OverlapPoint(rightUpWorld, vent) || Physics2D.OverlapPoint(rightDownWorld, vent);
    }

    /**
	 * Returns whether or not there is vent to the left.
	 */
    public bool IsVentLeft() {
        Vector2 leftUpWorld = (Vector2)transform.position + leftUpEdge;
        Vector2 leftDownWorld = (Vector2)transform.position + leftDownEdge;
        return Physics2D.OverlapPoint(leftUpWorld, vent) || Physics2D.OverlapPoint(leftDownWorld, vent);
    }

    public bool IsCharacterOverlapping() {
        Vector2 UpRightWorld = (Vector2)transform.position + insideUpRight;
        Vector2 UpLeftWorld = (Vector2)transform.position + insideUpLeft;
        Vector2 DownRightWorld = (Vector2)transform.position + insideDownRight;
        Vector2 DownLeftWorld = (Vector2)transform.position + insideDownLeft;
        List<Collider2D> results = new List<Collider2D> ();
        ContactFilter2D layer = new ContactFilter2D();
        layer.SetLayerMask(character);
        if(Physics2D.OverlapPoint(UpRightWorld, layer, results) > 1) return true;
        if(Physics2D.OverlapPoint(UpLeftWorld, layer, results) > 1) return true;
        if(Physics2D.OverlapPoint(DownRightWorld, layer, results) > 1) return true;
        if(Physics2D.OverlapPoint(DownLeftWorld, layer, results) > 1) return true;
        return false;
    }

    public bool IsCheckpointOverlapping() {
        Vector2 UpRightWorld = (Vector2)transform.position + insideUpRight;
        Vector2 UpLeftWorld = (Vector2)transform.position + insideUpLeft;
        Vector2 DownRightWorld = (Vector2)transform.position + insideDownRight;
        Vector2 DownLeftWorld = (Vector2)transform.position + insideDownLeft;
        return Physics2D.OverlapPoint(UpRightWorld, checkpoint) ||
        Physics2D.OverlapPoint(UpLeftWorld, checkpoint) ||
        Physics2D.OverlapPoint(DownRightWorld, checkpoint) ||
        Physics2D.OverlapPoint(DownLeftWorld, checkpoint);
    }

}
