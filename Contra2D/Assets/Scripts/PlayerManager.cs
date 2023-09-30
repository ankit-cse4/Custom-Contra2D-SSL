using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public AudioSource deathSound;
    public AudioSource damageSound;

    public float resetX;
    public GameObject bulletLeftUp;
    public GameObject bulletRightDown;
    public float resetY;
    public GameObject bulletRight;
    private bool isVisible;
    // private BoxCollider2D boxCollider;
    // private CircleCollider2D circleCollider;
    private bool readyToFall;

    public GameObject bulletLeft;
    public GameObject bulletRightUp;

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    public float jumpSpeed;
    public GameObject bulletLeftDown;
    public GameObject bulletUp;
    public GameObject bulletDown;
    private Transform firePositionS;
    private Transform firePositionWd;

    public int life;

    public float playerHealth;
    public float maxHealth = 100f;


    public float runningSpeed;
    private float speed;
    public bool horizontalLevel;

    private Transform firePosition;
    private Transform firePositionW;

    private float fireRate = 3f;
    float timeToFire = 0;
    public bool facingRight;
    private bool isDead = false;


    private bool onWater;
    private bool onGround;
    private bool jump = true;

    private bool bleach = false;
    public float gravity;

    public HealthBar healthBar;






    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        firePositionWd = transform.Find("FirePointW");
        firePositionS = transform.Find("FirePointS");
        firePositionW = transform.Find("FirePointOnlyW");



        // firePositionF = transform.Find("SpinningFirePoint");
        firePosition = transform.Find("FirePoint");
        // circleCollider = gameObject.GetComponent<CircleCollider2D>();
        // boxCollider = gameObject.GetComponent<BoxCollider2D>();
        facingRight = true;
        isVisible = true;
        playerHealth = maxHealth;
        healthBar.SetMaxHealth(100f);
        healthBar.SetHealth(playerHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Move(speed);
            Flip();
        }

        // if( Input.GetKeyDown(KeyCode.U) && onGround){
        //     animator.SetBool("Emote", true);

            
        // }
        // if( Input.GetKeyUp(KeyCode.U)){
        //     animator.SetBool("Emote", false);

            
        // }
        


        if (Input.GetKey(KeyCode.D))
        {
            speed = runningSpeed;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = -runningSpeed;
        }
        else
        {
            speed = 0;
        }

        if (readyToFall && Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S) && !jump)
        {
            jump = true;
            transform.position = new Vector2(transform.position.x, transform.position.y - gravity);

            animator.SetBool("Ground", false);

        }



        if (Input.GetKeyDown(KeyCode.Space) && !jump && !Input.GetKey(KeyCode.S) && !isDead
            && rigidbody2d.velocity.y == 0)
        {

            jump = true;
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x, jumpSpeed));

            animator.SetBool("Ground", false);
        }




        if (Input.GetKey(KeyCode.Z) && !onWater && onGround)
        {
            animator.SetBool("Crouch", true);
            speed = 0;

        }
        else
            animator.SetBool("Crouch", false);


        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
        }
        else
            animator.SetBool("Down", false);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
        }
        else
            animator.SetBool("Up", false);



        animator.SetFloat("Speed", Mathf.Abs(rigidbody2d.velocity.x));

        if (Input.GetKey(KeyCode.K) && Time.time > timeToFire && !isDead)
        {
            timeToFire = Time.time + 1 / fireRate;
            Fire();

        }
        if (onWater)
        {
            animator.SetBool("Water", true);
        }
        else
            animator.SetBool("Water", false);

        if (Input.GetKey(KeyCode.K))
        {
            animator.SetBool("Shooting", true);
            isVisible = true;
        }
        else
            animator.SetBool("Shooting", false);


    }



    private void Fire()
    {


        bool anyKey = false;



        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Instantiate(bulletDown, firePositionS.position, Quaternion.identity);
            anyKey = true;

        }



        else if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
        {
            Instantiate(bulletUp, firePositionW.position, Quaternion.identity);
            anyKey = true;
        }
        if (facingRight)
        {


            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                Instantiate(bulletRightDown, firePositionS.position, Quaternion.identity);
                anyKey = true;

            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                Instantiate(bulletRightUp, firePositionWd.position, Quaternion.identity);
                anyKey = true;

            }
            else if (!anyKey)
            {
                Instantiate(bulletRight, firePosition.position, Quaternion.identity);
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                Instantiate(bulletLeftDown, firePositionS.position, Quaternion.identity);
                anyKey = true;

            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                Instantiate(bulletLeftUp, firePositionWd.position, Quaternion.identity);
                anyKey = true;

            }
            else if (!anyKey)
            {
                Instantiate(bulletLeft, firePosition.position, Quaternion.identity);
            }
        }


    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "LifeUP"){
            if(life<5) {
                life +=1;
                Debug.Log(life);
            }
        }
        if(collision.gameObject.CompareTag("Invincible")){
            isVisible = false;
            
            Invoke(nameof(MakeVisible), 5f);

        }
        if(collision.gameObject.CompareTag("Heal")){
            if(playerHealth < 100){
                playerHealth += 20;
                healthBar.SetHealth(playerHealth);
                
                
        }
        }

        if (collision.gameObject.CompareTag("GROUND") )
        {
            readyToFall = true;
            onGround = true;
            onWater = false;
            bleach = true;
        }

        // if (collision.gameObject.CompareTag("Water")){
        //     bleach = false;

        // }

        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("GROUND") )
        {
            jump = false;
            animator.SetBool("Ground", true);
        }



        if (collision.gameObject.CompareTag("Water") && readyToFall )
        {
            readyToFall = false;
        }

        if (isVisible && (collision.gameObject.CompareTag("EnemiesBullet")))
        {
            //GetComponent<AudioSource>().Play();
            //Debug.Log("Collided with Enemy Bullet");
            if ((playerHealth <= 20f) && (jump == true))
            {
                //Debug.Log("Collided on jump");
                animator.SetBool("Ground", true);
                jump = false;
                //Debug.Log("Animation stopped on jump");
            }
            
            TakeDamage(20f);
            //Debug.Log("Damage Recieved");
        }

        if (isVisible && (collision.gameObject.CompareTag("MeelyEnemy") || collision.gameObject.CompareTag("SoldierEnemy")))
        {
            animator.SetBool("Ground", true);
            onGround = true;
            readyToFall = true;
            jump = false;
        }

        if (isVisible && (collision.gameObject.CompareTag("DeathLayer") ||
        collision.gameObject.CompareTag("Enemy") /*|| collision.gameObject.CompareTag("MeelyEnemy") || collision.gameObject.CompareTag("SoldierEnemy")*/))
        {
            deathSound.Play();

            Destroy(collision.gameObject, 0.5f);
            rigidbody2d.simulated = false;
            /*if (collision.gameObject.CompareTag("MeelyEnemy") *//* || collision.gameObject.CompareTag("SoldierEnemy")*//*)
            {
                StartCoroutine(WaitForSec(0.5f));
            }
            else
            {*/
                animator.SetBool("Dead", true);
                // circleCollider.isTrigger = true;
                // boxCollider.isTrigger = true;
                isVisible = false;


                

                isDead = true;
                life--;

                if (life == 0)
                {   
                    deathSound.Play();;
                    playerHealth = 0f;
                    healthBar.SetHealth(playerHealth);
                    Invoke(nameof(GameOver), 2f);

                }
                if (life != 0)
                {
                    playerHealth = 100f;
                    Invoke(nameof(RestartOne), 1f);
                    Invoke(nameof(Restart), 1f);
                    Invoke(nameof(MakeVisible), 5f);
                    /*healthBar.SetHealth(playerHealth);*/
                }
          /*  }*/
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            onWater = true;
            onGround = false;
        }





    }
    private IEnumerator WaitForSec(float sec)
    {
        yield return new WaitForSeconds(sec);
        /*animator.SetBool("Dead", true);
        isVisible = false;
        isDead = true;
        health--;
        if (health == 0)
        {
            playerHealth = 0f;
            healthBar.SetHealth(playerHealth);
            Invoke("GameOver", 2f);

        }
        if (health != 0)
        {
            playerHealth = 100f;
            Invoke("RestartOne", 1f);
            Invoke("Restart", 1f);
            Invoke("MakeVisible", 5f);
            healthBar.SetHealth(playerHealth);
        }*/
        if (life == 0)
        {
            deathSound.Play();
            healthBar.SetHealth(0f);
            /*boxCollider.isTrigger = true;
            circleCollider.isTrigger = true;*/
            /*rigidbody2d.simulated = false;*/
            Invoke(nameof(GameOver), 2f);
        }
        if (life != 0)
        {
            playerHealth = maxHealth;
            Invoke(nameof(RestartOne), 1f);
            Invoke(nameof(Restart), 2f);
            Invoke(nameof(MakeVisible), 5f);
            healthBar.SetHealth(playerHealth);
        }
    }


    private void Flip()
    {
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            Debug.Log("playerFlp");

        }
    }

    private void Move(float speed)

    {

        rigidbody2d.velocity = new Vector3(speed, rigidbody2d.velocity.y, 0);
    }
    private void Restart()
    {
        animator.SetBool("Dead", false);
        playerHealth = 100f;
        healthBar.SetHealth(playerHealth);
        // boxCollider.isTrigger = false;
        // circleCollider.isTrigger = false;
        rigidbody2d.simulated = true;

    }
    private void RestartOne()
    {
        if (!horizontalLevel)
        {
            transform.position = new Vector3(transform.position.x - resetX, transform.position.y + resetY, 0);

        }
        else
        {
            transform.position = new Vector3(transform.position.x - resetX, -0.8f, 0);

        }
        isDead = false;
        playerHealth = 100f;
        healthBar.SetHealth(playerHealth);
        animator.SetBool("Dead", false);

    }


    private void MakeVisible()
    {
        isVisible = true;
    }


    private void GameOver()
    {
        SceneManager.LoadScene(4);  
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            GetComponent<PlayerManager>().enabled = false;
        }
    }


    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        damageSound.Play();
        


        if (playerHealth <= 0)
        {
            deathSound.Play();
            rigidbody2d.simulated = false;
            life--;
            animator.SetBool("Dead", true);
            isVisible = false;
            isDead = true;
            StartCoroutine(WaitForSec(2f));
        }
        else
        {
            healthBar.SetHealth(playerHealth);
        } 
    }
}



