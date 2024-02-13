using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
            levelManager.LevelLost();

        }
    }
}
