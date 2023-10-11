using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeelyEnemy : MonoBehaviour
{
    public Transform player;
    public float attackDamage;
    public bool isFlipped;
    private bool isDead;
    private Animator animator;
    private BoxCollider2D boxCollidor;
    private CapsuleCollider2D capusuleCollidor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollidor = GetComponent<BoxCollider2D>();
        capusuleCollidor = GetComponent<CapsuleCollider2D>();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet") || coll.gameObject.CompareTag("DeathLayer") || coll.gameObject.CompareTag("Bounds") || coll.gameObject.CompareTag("Water"))
        {
            boxCollidor.enabled = false;
            capusuleCollidor.enabled = false;
            isDead = true;
            Debug.Log("Animation Should start");
            animator.SetBool("Dead", true);
            Debug.Log("Animation started");
            Destroy(gameObject, 0.5f);
        }

       /* if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("It starts");
            coll.gameObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("Damage given to player.");
        }*/
    }
}
