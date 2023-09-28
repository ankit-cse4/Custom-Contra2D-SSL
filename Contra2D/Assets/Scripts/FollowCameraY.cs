using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraY : MonoBehaviour
{

    public Transform cam;

    private float yDistance = 9f;

    void Start()
    {
        // yDistance = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, cam.position.y-yDistance, transform.position.z);

    }
}
