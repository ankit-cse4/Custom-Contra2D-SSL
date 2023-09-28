using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform cam;

    private float xDistance = 25;

    void Start()
    {
        // xDistance ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x - xDistance, transform.position.y, transform.position.z);
        
    }
}
