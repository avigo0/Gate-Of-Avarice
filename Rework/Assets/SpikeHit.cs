using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHit : MonoBehaviour {
    float respawnX;
    float respawnY;
    void Start()
    {
        respawnX = -5.59f;
        respawnY = -1.55f;
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Spikes"){
            Debug.Log("Kill");
            gameObject.transform.position = new Vector2(respawnX, respawnY);
        }
    }
}

