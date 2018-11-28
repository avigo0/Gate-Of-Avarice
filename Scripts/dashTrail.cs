using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTrail : MonoBehaviour {

    public ParticleSystem dashLeft, dashRight;
    //public cameraShake cameraShake;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("d") && (!dashRight.isPlaying))
        {
            dashRight.Emit(10);
            //StartCoroutine(cameraShake.Shake(15f, 4f));
        }
        if (Input.GetKeyDown("a") && (!dashLeft.isPlaying))
        {
            dashLeft.Emit(10);
        }
	}
}
