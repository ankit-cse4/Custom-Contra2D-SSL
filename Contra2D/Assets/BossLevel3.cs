using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel3 : MonoBehaviour
{
    private int health;
    /*private BoxCollider2D boxCollider;*/
    /*private Animator animator;*/
    public GameObject bossBullet1;
    public GameObject bossBullet2;
    /*private GameObject finish;*/
    private Transform bossFirePoint1;
    private Transform bossFirePoint2;
    private Transform bossFirePoint3;
    private Transform bossFirePoint4;
    private Transform bossFirePoint5;
    private Transform bossFirePoint6;
    private Transform targetPlayer;
    private GameObject universeBoss;
    private bool isDead = false;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        /*animator = GetComponent<Animator>();*/
        targetPlayer = GameObject.Find("Player").transform;
        bossFirePoint1 = transform.Find("RightBoss").Find("UniversalBossFirePoint1");
        bossFirePoint2 = transform.Find("RightBoss").Find("UniversalBossFirePoint2");
        bossFirePoint3 = transform.Find("RightBoss").Find("UniversalBossFirePoint3");
        bossFirePoint4 = transform.Find("RightBoss").Find("UniversalBossFirePoint4");
        bossFirePoint5 = transform.Find("RightBoss").Find("UniversalBossFirePoint5");
        bossFirePoint6 = transform.Find("RightBoss").Find("UniversalBossFirePoint6");
        universeBoss = GameObject.Find("UniversalBoss");

        if (!isDead)
        {
            InvokeRepeating("Shoot", 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }

        if (health <= 2 && !isDead)
        {
            InvokeRepeating("Shoot", 0, 1f);
        }
        if (health ==0)
        {
            isDead = true;
            //universeBoss.GetComponent<UniversalBoss>().BossDied();
            GetComponent<AudioSource>().Play();
            /*animator.SetBool("Dead", true);*/
            Destroy(gameObject, 0f);
        }
    }

    private void Shoot()
    {
        if (health != 0)
        {
            Instantiate(bossBullet1, bossFirePoint1.position, Quaternion.identity);
            Instantiate(bossBullet1, bossFirePoint2.position, Quaternion.identity);
            Instantiate(bossBullet1, bossFirePoint3.position, Quaternion.identity);
            Instantiate(bossBullet1, bossFirePoint4.position, Quaternion.identity);
            Instantiate(bossBullet2, bossFirePoint5.position, Quaternion.identity);
            Instantiate(bossBullet2, bossFirePoint6.position, Quaternion.identity);
        }
    }
}
