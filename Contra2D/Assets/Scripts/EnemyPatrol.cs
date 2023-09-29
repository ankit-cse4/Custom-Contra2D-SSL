using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Transform currPoint;
    [SerializeField]private float enemySpeed;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        currPoint = rightPoint.transform;
        direction = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 point = currPoint.position - transform.position;
        if (currPoint == rightPoint.transform)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * enemySpeed * direction, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * enemySpeed * direction, transform.position.y, transform.position.z);
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == rightPoint.transform)
        {
            // Flip();
            direction = -direction;
            currPoint = leftPoint.transform;
        }
        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == leftPoint.transform)
        {
            // Flip();
            direction = -direction;
            currPoint = rightPoint.transform;
        }
    }

    private void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;
        transform.localScale = flipped;
        direction *= -1f;
    }
}