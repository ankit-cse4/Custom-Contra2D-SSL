using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeUniversalBoss : MonoBehaviour
{
    [SerializeField] private GameObject universalBoss;
    private Transform bossPosition;
    // Start is called before the first frame update
    private void Start()
    {
        bossPosition = transform.Find("BossPosition");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(universalBoss, bossPosition.position, Quaternion.identity);
            transform.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
}
