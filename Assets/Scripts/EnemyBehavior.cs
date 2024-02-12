using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public Transform player;
    public float moveSpeed = 10.0f;
    public AudioClip enemyDestroyedSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if game not over
        transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            AudioSource.PlayClipAtPoint(enemyDestroyedSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
