//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class Attack : StateMachineBehaviour
//{
//    [Range(0f, 100f)]
//    //public float chasetoattack;
//    public NavMeshAgent agent;
//    public Animator animator;
//    Transform player;
//    public float attackRange = 1.5f;



//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.applyRootMotion = true;
//        agent =animator.GetComponent<NavMeshAgent>();
//       player = GameObject.FindGameObjectWithTag("Player").transform;

//    }

//    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {

//        if (EnemyFOV.instance.isDetected)
//        {
//            // PlayerRange to Attack Player

//          if (Vector3.Distance(player.position, animator.transform.position) <= attackRange)
//            {
//                animator.SetTrigger("IsAttacking");
//            }
//            else
//            {
//                // If the player is not within attack range, chase the player
//                animator.SetBool("IsChasing", true);
//            }
//        }
//        else
//        {
//            animator.SetBool("IsPatrolling", true);
//        }


//    }


//    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if(!EnemyFOV.instance.isChasing)
//        {
//            animator.SetBool("IsPatrolling",true) ;

//        }
//        animator.applyRootMotion = false;
//        Debug.Log("not");
//    }

//    // OnStateMove is called right after Animator.OnAnimatorMove()
//    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    // Implement code that processes and affects root motion
//    //}

//    // OnStateIK is called right after Animator.OnAnimatorIK()
//    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    // Implement code that sets up animation IK (inverse kinematics)
//    //}
//}
