using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    bool check;
    public EnemyData enemyData;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!check)
        {
            enemyData = animator.GetComponent<EnemyData>();
        }
        enemyData.agent.isStopped = false;
        enemyData.agent.speed = enemyData.walkSpeed;
        if (animator.applyRootMotion == true) { animator.applyRootMotion = false; }
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("EnemyIdle", EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.minDistanceWalk);
        animator.SetBool("EnemyWalk", EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.minDistanceWalk && EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.maxDistanceWalk);
        animator.SetBool("EnemyChase", EnemyHolder.instance.CalculateDistance(animator.transform.position) >enemyData.maxDistanceWalk);
        enemyData.agent.SetDestination(EnemyHolder.instance.player.position);
    }
}
