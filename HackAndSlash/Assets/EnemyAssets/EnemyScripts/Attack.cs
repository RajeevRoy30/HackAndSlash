using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachineBehaviour
{
    //[Range(0f, 100f)]
    ////public float chasetoattack;
    //public NavMeshAgent agent;
    //public Animator animator;
    //Transform player;
    //public float attackRange = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent =animator.GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //animator.SetBool("IsChasing", false);
        //PlayerManger.instance.StartCoroutine(AttackMotion(stateInfo.length, animator));
        if(animator.applyRootMotion == false)
        {
            animator.applyRootMotion=true;
        }
        //animator.transform.GetComponent<NavMeshAgent>().enabled=false;

    }
    [SerializeField] int comboCount;
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("EnemyAttack", comboCount);
    }


    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if(!EnemyFOV.instance.isChasing)
        //{
        //    animator.SetBool("IsPatrolling",true) ;
        //}
        //animator.SetBool("IsChasing", false);
    }
    IEnumerator AttackMotion(float time,Animator anim)
    {
        anim.applyRootMotion=true;
        yield return new WaitForSeconds(time);
        anim.applyRootMotion = false;
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
