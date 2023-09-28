using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    public Vector2 speed;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = speed;
        
	}

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = speed;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Water") ||
            collision.gameObject.CompareTag("DeathLayer") || collision.gameObject.CompareTag("MeelyEnemy") || collision.gameObject.CompareTag("SoldierEnemy"))
        {
            Destroy(gameObject, 0);
        }
        
    }
}
