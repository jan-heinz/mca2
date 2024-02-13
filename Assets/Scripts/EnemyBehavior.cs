using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public Transform player;
    public float moveSpeed = 10.0f;
    public AudioClip enemyDestroyedSFX;
    
    LevelManager levelManager;

    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>(); // finds the levelManager for this current scene

        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.isGameOver) {
            transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
                AudioSource.PlayClipAtPoint(enemyDestroyedSFX, Camera.main.transform.position);
                gameObject.GetComponent<Animator>().SetTrigger("enemyDestroyed");
                Destroy(gameObject, 1);
        }
    }
}
