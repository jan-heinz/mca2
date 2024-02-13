using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBlock : MonoBehaviour {

    public float bounceStrength = 10.0f;
    public Color colorOne = Color.green;
    public Color colorTwo = Color.magenta;
    public float colorChangeSpeed = 1.0f;

    Renderer blockRenderer;
    float colorChangeTime;
    
    
    // Start is called before the first frame update
    void Start() {
        blockRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        colorChangeTime = Mathf.PingPong(Time.time * colorChangeSpeed, 1);
        blockRenderer.material.color = Color.Lerp(colorOne, colorTwo, colorChangeTime);
    }

    void OnCollisionEnter(Collision other) {
        // finds bounce direction (upwards and opposite to collision)
        // found these methods looking through documentation
        // haven't been covered but it just deals w/ Vector3 object so I thought it would be okay
        Vector3 bounceDirection = Vector3.Reflect(other.relativeVelocity, other.contacts[0].normal).normalized;
        Vector3 bounceForce = bounceDirection * bounceStrength;
        
        other.rigidbody.AddForce(bounceForce, ForceMode.Impulse);
    }
}
