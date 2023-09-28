using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleIdle : StateMachineBehaviour
{
    private float distance;
    private Transform player;
    Rigidbody2D rigidbody;
    MeelyEnemy meeleEnemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        meeleEnemy = animator.GetComponent<MeelyEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meeleEnemy.LookAtPlayer();
        distance = Mathf.Abs(player.position.x - rigidbody.position.x);
        if (distance <= 15f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    
}
