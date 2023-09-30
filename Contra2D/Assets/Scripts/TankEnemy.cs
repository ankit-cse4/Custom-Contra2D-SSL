using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankEnemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipped;
    private float tankSpeed = 1f;
    private Animator animator;
    public GameObject enemyBullet;
    private float distance;
    private float tankHealth = 10;
    private Transform firePosition;
    private bool move = true;
    private bool isDead = false;
    private bool temp = false;
    private float dir = -1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        firePosition = transform.Find("EnemyTankFirePoint");
        if (!isDead)
        {
            InvokeRepeating("Shoot", 0, 0.5f);
        }
        LookAtPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance < 20f)
        {
            temp = true;

            if (distance > 2f && move)
            {
                Debug.Log(dir);
                transform.position = new Vector3(transform.position.x + Time.deltaTime * tankSpeed * dir, transform.position.y, transform.position.z);
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }
        else temp = false;

        if (isDead)
        {
            animator.SetTrigger("Destroy");
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z = -flipped.z;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            dir = -1;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
            dir = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TankCollider"))
        {
            move = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && !isDead)
        {
            Destroy(other.gameObject);
            tankHealth--;
        }
        if (tankHealth <= 0)
        {
            isDead = true;
            animator.SetBool("Move", false);
            animator.SetBool("Idle", false);
            animator.ResetTrigger("Shot");
            animator.SetTrigger("Destroy");
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
            animator.SetTrigger("Shot");
            Instantiate(enemyBullet, firePosition.position, Quaternion.identity);
        }
        else
        {
            animator.ResetTrigger("Shot");
        }

    }


}
