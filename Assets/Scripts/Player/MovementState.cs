﻿using UnityEngine;

public class MovementState {
    public Vector3 pos;
    public Vector3 vel;
    public bool isGroundUp;
    public bool isGroundDown;
    public bool isGroundRight;
    public bool isGroundLeft;

    public MovementState(GameObject gameObject) {
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        pos = new Vector3(rigidbody.position.x, rigidbody.position.y, 0);
        vel = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);

        CollisionAnalysis collisionAnalysis = gameObject.GetComponent<CollisionAnalysis>();
        isGroundUp = collisionAnalysis.IsGroundUp();
        isGroundDown = collisionAnalysis.IsGroundDown();
        isGroundRight = collisionAnalysis.IsGroundRight();
        isGroundLeft = collisionAnalysis.IsGroundLeft();
    }

    public MovementState(MovementState state) {
        pos = new Vector3(state.pos.x, state.pos.y, state.pos.z);
        vel = new Vector3(state.vel.x, state.vel.y, state.vel.z);
        isGroundUp = state.isGroundUp;
        isGroundDown = state.isGroundDown;
        isGroundRight = state.isGroundRight;
        isGroundLeft = state.isGroundLeft;
    }
}
