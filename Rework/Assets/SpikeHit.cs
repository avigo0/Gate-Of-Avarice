using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHit : MonoBehaviour {
    float respawnX;
    float respawnY;
    Rigidbody2D rb;
    void Start()
    {
        respawnX = -5.59f;
        respawnY = -1.55f;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Spikes"){
            rb.velocity = Vector3.zero;
            gameObject.transform.position = new Vector2(respawnX, respawnY);
        }
    }
}

