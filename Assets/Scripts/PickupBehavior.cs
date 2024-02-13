using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour {

    public static int score = 0;
    public static int numPickups;
    public static int scoreValue = 1;
    public AudioClip pickUpSFX;

    LevelManager levelManager;


    // Start is called before the first frame update
    void Start() {
        levelManager = FindObjectOfType<LevelManager>(); // finds the levelManager for this current scene
        numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        score = 0;
    }

    // Update is called once per frame
    void Update() {
        // if (LevelManager.isGameOver) {
        //   score = 0;
        // }
        
        numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length; 
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

    void OnDestroy() {
        
        // decrement only if numPicksUps is greater than 0
        if (numPickups > 0) numPickups--; 
    
        // decrement only if numPicksUps is 
        if (numPickups == 0 && levelManager != null) {
            FindObjectOfType<LevelManager>().LevelBeat();
        }
    }
}
