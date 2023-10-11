using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniversalBoss : MonoBehaviour
{
    private Transform firePoint1;
    private Transform firePoint2;
    private Transform leftBoss;
    private Transform rightBoss;

    private bool isDead = false;
    private BoxCollider2D boxCollider2D;
    private Transform targetPlayer;
    /*private GameObject levelComplete;*/
    /*private Animator animator;*/
    private int health;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject boss;
    private bool boss1Dead;
    private bool boss2Dead;
    private int totalBoss = 2;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        boxCollider2D = GetComponent<BoxCollider2D>();
        /*animator = GetComponent<Animator>();*/
        targetPlayer = GameObject.Find("Player").transform;
        /*levelComplete = GameObject.Find("LevelComplete");*/
        firePoint1 = transform.Find("BossLevel3").Find("UniverseBossFirePoint1");
        firePoint2 = transform.Find("BossLevel3").Find("UniverseBossFirePoint2");
        leftBoss = transform.Find("LeftBoss");
        leftBoss.position = new Vector3(leftBoss.position.x - 5.4f, leftBoss.position.y, leftBoss.position.z);
        rightBoss = transform.Find("RightBoss");
        rightBoss.position = new Vector3(rightBoss.position.x - 5.4f, rightBoss.position.y, rightBoss.position.z);

        if (!isDead)
        {
            InvokeRepeating("Shoot", 0, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Collided");
            if (health > 6)
            {
                health--;
            }
            else if (health == 6)
            {
                health--;
                Instantiate(boss, leftBoss.position, Quaternion.identity);
                Instantiate(boss, rightBoss.position, Quaternion.identity);
            }
            else
            {
                // if (boss1Dead && boss2Dead)
                // {
                //     health--;
                // }
                health--;
            }
        }
        if (health == 0)
        {
            isDead = true;
            GetComponent<AudioSource>().Play();
            /*animator.SetBool("Dead", true);*/
            /*levelComplete.GetComponent<BoxCollider2D>().enabled = false;*/
            Destroy(gameObject, 2f);
            Invoke(nameof(LoadNext), 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Shoot()
    {
        if (health != 0)
        {
            Instantiate(bullet1, firePoint1.position, Quaternion.identity);
            Instantiate(bullet2, firePoint2.position, Quaternion.identity);
        }
    }

    public void BossDied()
    {
        totalBoss--;
        if (totalBoss == 1)
        {
            boss1Dead = true;
        }
        else if (totalBoss == 0) 
        {
            boss2Dead = true;
        }
    }
}
