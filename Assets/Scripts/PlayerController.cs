using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce = 5f;
    public float speed = 2f;

    Rigidbody rigidBody;
    
    private float originalSpeed; // temp variable to hold original speed value that we can swap back too
    
    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update() {
        // jump only if user presses space and player is on ground
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.7f) {
            rigidBody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        // user presses shift, double speed
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed *= 2;
        }

        // user unpresses shift, revert to original speed
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = originalSpeed;
        }
    }

    void FixedUpdate() {
        if (!LevelManager.isGameOver) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 forceVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rigidBody.AddForce(forceVector * speed);
        }
        else {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}