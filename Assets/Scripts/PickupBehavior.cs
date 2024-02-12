using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour {

    public static int score = 0;
    public static int scoreValue = 1;
    public AudioClip pickUpSFX;

    LevelManager levelManager;
    
    
    // Start is called before the first frame update
    void Start() {
        levelManager = FindObjectOfType<LevelManager>(); // finds the levelManager for this current scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // picked up before half way point
            if (levelManager.countDown > levelManager.levelDuration / 2) {
                score += scoreValue * 2;
            }
            else {
                score += scoreValue;
            }
            AudioSource.PlayClipAtPoint(pickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
