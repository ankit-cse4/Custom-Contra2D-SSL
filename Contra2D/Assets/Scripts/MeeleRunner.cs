using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeeleRunner : StateMachineBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float followRange = 10f;
    public float distance;
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
        if (Vector2.Distance(player.position, rigidbody.position) <= attackRange)
        {           
            animator.SetTrigger("Attack");
        }
        if (distance < 15f && distance >1f ) 
        { 
            Vector2 target = new(player.position.x, rigidbody.position.y);
            Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, moveSpeed * Time.fixedDeltaTime);
            rigidbody.MovePosition(newPos);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        /*if (Vector2.Distance(player.position, rigidbody.position) <= followRange)
        {
            animator.SetBool("Run", true);
            
        }*/
        /*else
        {
            animator.SetBool("Run", false);
        }*/


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.ResetTrigger("Attack");
    }

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
