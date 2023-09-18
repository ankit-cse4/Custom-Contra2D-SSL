using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        // transform.Rotate(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, steerSpeed);

        transform.Translate(0, moveSpeed, 0);
    }
}
