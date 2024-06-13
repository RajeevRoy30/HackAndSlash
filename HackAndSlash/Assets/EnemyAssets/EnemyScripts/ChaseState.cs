using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ChaseState : StateMachineBehaviour
{
    public EnemyData enemyData;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyData == null && animator.TryGetComponent(out EnemyData enemy))
        {
            enemyData = enemy;
        }
        enemyData.agent.isStopped = false;
        enemyData.agent.speed = enemyData.chaseSpeed;
        if (animator.applyRootMotion == true) { animator.applyRootMotion = false; }
    }
    [SerializeField] float JumpAttackMin,JumpAttacMax;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (EnemyHolder.instance.CalculateDistance(animator.transform.position) >= JumpAttackMin&& EnemyHolder.instance.CalculateDistance(animator.transform.position) <=JumpAttacMax)
        //{
        //    Debug.LogError("JumpAttack Performed");
        //    animator.SetTrigger("SpecialAttack");
        //}
        animator.SetBool("EnemyIdle", EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.minDistanceWalk);
        animator.SetBool("EnemyWalk", EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.minDistanceWalk && EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.maxDistanceWalk);
        animator.SetBool("EnemyChase", EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.maxDistanceWalk);
        enemyData.agent.SetDestination(EnemyHolder.instance.player.position);
    }
}
