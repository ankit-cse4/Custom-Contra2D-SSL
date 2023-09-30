using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletB : MonoBehaviour {
    private Vector2 speed;
    private Rigidbody2D rigidBody;
    private bool yDistance;
    private Transform player;
    
    private float yaxis;

    private float xaxis;
    private bool xDistance;
    // Use this for initialization
    void Start () {

        // rigidBody = GetComponent<Rigidbody2D>();
        // rigidBody.AddForce(new Vector2(Random.Range(-300, 300), Random.Range(300, 400)));


        GameObject myObject = GameObject.Find("Player");
        player = myObject.transform;

        rigidBody = GetComponent<Rigidbody2D>();
        xaxis = (player.position.x - transform.position.x);
        yaxis = (player.position.y - transform.position.y);


        // if (xaxis > 0)
        // {
        //     xDistance = true;
        // }
        // else xDistance = false;
        // if (yaxis > 0)
        // {
        //     yDistance = true;
        // }
        // else
        // yDistance = false;

       
       
        rigidBody.velocity = new Vector2(xaxis, yaxis).normalized * 9;
       
   
    }
	
	// Update is called once per frame
	void Update () {

        Physics2D.IgnoreLayerCollision(10, 12, true);
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0);
        }

    }
    
}
