using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Vector3 currPoint;
    private bool movingRight;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField]private float enemySpeed;
    [SerializeField] private Transform patrolPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        currPoint = patrolPoint.localScale;
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingRight)
        {
            if (patrolPoint.position.x >= leftPoint.position.x)
            {
                // change direction in movement
                Move(-1);
            }
            else
            {
                movingRight = !movingRight;
            }
        }
        else
        {
            if (patrolPoint.position.x <= rightPoint.position.x)
            {
                // move in same direction
                Move(1);
            }
            else
            {
                movingRight = !movingRight;
            }
        }

    }
     private void Move(int dir)
    {
        float x = Mathf.Abs(currPoint.x) * dir;
        // Change the direction in the facing of movement
        patrolPoint.localScale = new Vector3(x, currPoint.y, currPoint.z);
        // Moving to the updated location
        patrolPoint.position = new Vector3(patrolPoint.position.x + Time.deltaTime * enemySpeed * dir, 
            patrolPoint.position.y, patrolPoint.position.z);
    }
}
