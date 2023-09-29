using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankIdle : StateMachineBehaviour
{
    private float distance;
    private Transform player;
    private Transform transform;
    public bool isFlipped;
    TankEnemy tankEnemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform = animator.GetComponent<Transform>();
        tankEnemy = animator.GetComponent<TankEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tankEnemy.LookAtPlayer();
        distance = Mathf.Abs(player.position.x - transform.position.x);
        if (distance <= 15f)
        {
            if (distance > 2f)
            {
                animator.SetBool("Move", true);
            }
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
