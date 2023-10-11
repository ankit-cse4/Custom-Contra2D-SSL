using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    private int health = 1;
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

    private Animator anim;
    Transform myObject;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GameObject.FindWithTag("Player").transform;
        target = myObject.transform;
        firePosition = transform.Find("EnemyFirePoint");
        anim = gameObject.GetComponent<Animator>();
        if (!isDead)
        {
            InvokeRepeating("Shoot", 0, 2f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        distance = Mathf.Abs(transform.position.x - target.position.x) + Mathf.Abs(transform.position.y - target.position.y);
        if (distance < 30f)
        {
            temp = true;
        }
        else temp = false;
        
        
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
            anim.SetBool("Destroy",true);
            Destroy(gameObject, 1f);
            
        }
        else
        {
            isDead = false;
        }
    }

    public float checkAngle()
    {



        A = new Vector2(transform.position.x, transform.position.y);
        B = new Vector2(target.position.x, target.position.y);
        C = B - A;


        angle = Mathf.Atan2(C.y, C.x) * Mathf.Rad2Deg;
        angle = Mathf.Round(angle / 30) * 30;

        return angle;
    }


    private void Shoot()
    {

        if (temp && !isDead)
        {
            Instantiate(enemyBullet, firePosition.position, Quaternion.identity);

        }

    }
}
