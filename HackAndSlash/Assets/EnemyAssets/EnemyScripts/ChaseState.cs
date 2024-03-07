using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    float speed = 10f;
    Transform player;
    public Animator animator;
    public float attackRange = 3f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        agent = animator.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = 5f;
         
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.SetDestination(player.position);
        //{

        //}
        if (EnemyFOV.instance.isDetected)
        {
            agent.SetDestination(player.position);

            Debug.Log(Vector3.Distance(player.position, animator.transform.position));

            if (Vector3.Distance(player.position, animator.transform.position) <= attackRange)
            {
                animator.SetTrigger("IsAttacking");
                Debug.Log("attacking");
            }
            //else
            //{
            //    // If the player is not within attack range, chase the player
            //    animator.SetBool("IsChasing", true);
            //    Debug.Log("chasing");
            //}


            //animator.SetBool("IsChasing", false);
            
            //animator.SetTrigger("IsAttacking");
        }
       // else if (EnemyFOV.instance.isChasing)
        //{
        //    animator.SetBool("IsChasing", true);
        //    agent.SetDestination(player.position);
        //    animator.SetTrigger("IsAttacking");
       
        //}
        else
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsPatrolling", true);
        }

    }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //    agent.SetDestination(player.transform.position);
    }

    //OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

   // OnStateIK is called right after Animator.OnAnimatorIK()
   // override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   // {
        // Implement code that sets up animation IK (inverse kinematics)
    //}
}
