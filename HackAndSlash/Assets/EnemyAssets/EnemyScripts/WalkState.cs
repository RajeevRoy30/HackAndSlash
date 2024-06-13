using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    public EnemyData enemyData;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyData == null && animator.TryGetComponent(out EnemyData enemy))
        {
            enemyData = enemy;
        }
        enemyData.agent.isStopped = false;
        enemyData.agent.speed = enemyData.walkSpeed;
        if (animator.applyRootMotion == true) { animator.applyRootMotion = false; }
    }
    [SerializeField] float JumpAttackMin,JumpAtttackMax;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.LogError(EnemyHolder.instance.CalculateDistance(animator.transform.position));
        if(EnemyHolder.instance.CalculateDistance(animator.transform.position) >= JumpAttackMin && EnemyHolder.instance.CalculateDistance(animator.transform.position)<JumpAtttackMax)
        {
            //Debug.LogError("JumpAttack Performed");
            animator.SetTrigger("SpecialAttack");
            enemyData.agent.isStopped=true;
        }
        animator.SetBool("EnemyIdle", EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.minDistanceWalk);
        animator.SetBool("EnemyWalk", EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.minDistanceWalk && EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.maxDistanceWalk);
        animator.SetBool("EnemyChase", EnemyHolder.instance.CalculateDistance(animator.transform.position) >enemyData.maxDistanceWalk);
        enemyData.agent.SetDestination(EnemyHolder.instance.player.position);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyData.agent.isStopped = false;
    }
}
