using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private float distance;
    private Transform firePosition2;
    public int health;
    private bool isDead = false;
    private BoxCollider2D boxCollider;
    
    public GameObject bullet;
    private Transform firePosition;
    
    
    private Transform target;
    private Animator animator;
    


    // Use this for initialization
    void Start () {
        health = 8;
        // boxCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        GameObject myObject = GameObject.Find("Player");
        target = myObject.transform;
        firePosition2 = transform.Find("FirePointTwo");
        firePosition = transform.Find("FirePoint");
       
        if( !isDead){ 

            InvokeRepeating("Shoot", 0, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;
       
        }
        if(health == 0)
        {
            GetComponent<AudioSource>().Play();
            animator.SetBool("Destroyed", true);
            Destroy(gameObject, 1f);
            isDead = true;
            

           
        }
    }

    private void Shoot()
    {
        distance = Mathf.Abs(target.position.x - transform.position.x);
        if (health > 0 && distance < 20f  )
        {
            Instantiate(bullet, firePosition2.position, Quaternion.identity);
            Instantiate(bullet, firePosition.position, Quaternion.identity);

        }
    }
}
