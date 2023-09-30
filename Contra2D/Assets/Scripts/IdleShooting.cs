using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleShooting : MonoBehaviour
{

    private int health = 2;
    public bool invinsible;

    public GameObject enemyBullet;
    // public GameObject deathEffectFirst;
    // public GameObject deathEffectSecond;
    public GameObject particles;
    private Transform firePosition;
    private Transform target;

    private float distance;

    private float angle;
    private bool temp = false;
    private Vector2 A, B, C;
    private bool isDead = false;
    public float fireRate;

    private Animator anim;
    Transform myObject;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GameObject.FindWithTag("Player").transform;
        target = myObject.transform;
        firePosition = transform.Find("EnemyFirePoint");

        InvokeRepeating("Shoot", 0, fireRate);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x >= transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        distance = Mathf.Abs(transform.position.x - target.position.x) + Mathf.Abs(transform.position.y - target.position.y);
        if (distance < 35f)
        {
            temp = true;
        }
        else temp = false;
        // anim.SetInteger("Angle",(int) checkAngle());
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
        }
         if (health <= 0)
        {
            isDead = true;
            GetComponent<AudioSource>().Play();
            //Instantiate(particles, transform.position, transform.rotation);
            anim.SetBool("Destroyed",true);
            Destroy(gameObject, 1f);
            
        }
        else
        {
            isDead = false;
        }
    }


    private void Shoot()
    {

        if (temp && !isDead)
        {
            Instantiate(enemyBullet, firePosition.position, Quaternion.identity);

        }

    }
}
