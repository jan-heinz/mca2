using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
    Vector3 offSet;
    
    // Start is called before the first frame update
    void Start() {
        // lecture code that allows camera to follow player
        player = GameObject.FindGameObjectWithTag("Player");
        offSet = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (player != null) {
            transform.position = player.transform.position + offSet;
        }
    }
}
