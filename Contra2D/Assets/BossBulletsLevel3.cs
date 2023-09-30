using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletsLevel3 : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-500, 500), Random.Range(-5, -1)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
