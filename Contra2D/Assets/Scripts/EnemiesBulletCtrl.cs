using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBulletCtrl : MonoBehaviour {

    private bool yDistance;
    private Transform player;
    
    private float yaxis;
    Rigidbody2D rigidBody;
    private float xaxis;
    private bool xDistance;
    




    void Start() {
        GameObject myObject = GameObject.Find("Player");
        player = myObject.transform;

        rigidBody = GetComponent<Rigidbody2D>();
        xaxis = (player.position.x - transform.position.x);
        yaxis = (player.position.y - transform.position.y);


        if (xaxis > 0)
        {
            xDistance = true;
        }
        else xDistance = false;
        if (yaxis > 0)
        {
            yDistance = true;
        }
        else
        yDistance = false;

       
       
        rigidBody.velocity = new Vector2(xaxis, yaxis).normalized * 9;
       
   
    }
	
	// Update is called once per frame
	void Update () 
    {
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
