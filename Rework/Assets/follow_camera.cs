using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_camera : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        tempVec3.x = targetTransform.position.x;
        tempVec3.y = this.transform.position.y;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}