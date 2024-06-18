using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack1 : Attack
{
    private EnemyData enemyData;
    Vector3 temp;
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ConbactManager.instance.canRecieveInput=true;
        animator.applyRootMotion = true;
        if(enemyData == null&& animator.TryGetComponent(out EnemyData enemy)) 
        {
            enemyData = enemy;
        }
        temp=EnemyHolder.instance.player.transform.position;
        enemyData.agent.SetDestination(temp);
        //enemyData.EnableSwordCollider();
        //enemyData.hitValue = 4;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SwordDetect(stateInfo);
       // ConbactManager.instance.canRecieveInput=true;
        //if (ConbactManager.instance.inputRecieved)
        //{
        //    animator.SetTrigger("Attack1");
        //    ConbactManager.instance.InputManager();
        //    ConbactManager.instance.inputRecieved= false;
        //}
        //if(animator.TryGetComponent(out NavMeshAgent agent))
        //{
        //    agent.SetDestination(EnemyHolder.instance.player.position);
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemyData.DisableSwordCollider();
        //enemyData.hitValue = 0;
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
