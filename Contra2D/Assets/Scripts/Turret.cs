using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    

    
    private Transform firePosition;
    private Transform target;

    public GameObject particles;
    public GameObject enemyBullet;

    private float distance;
    private int health = 4;

    private bool range = false;
    private bool isDead = false;
    // private CircleCollider2D circleCollider;
    private Animator animator;

    public float fireRate;
    
    public Vector3 diff;
    
    // Use this for initialization
    void Start () {
        GameObject myObject = GameObject.Find("Player");
        target = myObject.transform;
        firePosition = transform.Find("EnemyFirePoint");
        // circleCollider = gameObject.GetComponent<CircleCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        if (!isDead)
        {
            InvokeRepeating("Shoot", 0, fireRate);
        }
    }
	
	// Update is called once per frame
	void Update () {

        diff = target.position - transform.position;
		var diffNorm = diff.normalized;
		float rot_z = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        


        distance = Mathf.Abs(transform.position.y - target.position.y) + Mathf.Abs(transform.position.x - target.position.x);;
        if (distance >= 25f)
        {
            range = false;
        }
        else{
            
            range = true;

        } 
       
    }
    private void Shoot()
    {

        if (range && !isDead)
        {
            Instantiate(enemyBullet, firePosition.position, Quaternion.identity);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
         if (health <= 0)
        {
            GetComponent<AudioSource>().Play();
            isDead = true;
            
            // Instantiate(particles, transform.position, transform.rotation);
            animator.SetBool("Destroyed", true);
            Destroy(gameObject, 1f);
        }
        else
        {
            isDead = false;
        }
    }
}
