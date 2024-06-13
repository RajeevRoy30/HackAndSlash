using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    public EnemyData enemyData;
    [SerializeField] float TimeToAttack;
    float TimerCounter;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyData == null && animator.TryGetComponent(out EnemyData enemy))
        {
            enemyData = enemy;
        }
        enemyData.SwordCollider.enabled = false;
        enemyData.agent.isStopped = true;
        enemyData.agent.speed = 0;
        TimerCounter = Time.time;
        if(animator.applyRootMotion==true) { animator.applyRootMotion = false; }
        animator.SetInteger("EnemyHit", 0);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyHolder.instance.EnemyLookAt(animator.transform);
        //if(EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.minDistanceWalk && EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.maxDistanceWalk)
        //{
        //}
        //Debug.Log(EnemyHolder.instance.CalculateDistance(animator.transform.position));
        //Debug.Log(EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.minDistanceWalk && EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.maxDistanceWalk);
        animator.SetBool("EnemyWalk", EnemyHolder.instance.CalculateDistance(animator.transform.position)>enemyData.minDistanceWalk&& EnemyHolder.instance.CalculateDistance(animator.transform.position)<=enemyData.maxDistanceWalk);
        animator.SetBool("EnemyIdle", EnemyHolder.instance.CalculateDistance(animator.transform.position) <= enemyData.minDistanceWalk);
        animator.SetBool("EnemyChase", EnemyHolder.instance.CalculateDistance(animator.transform.position) > enemyData.maxDistanceWalk);
        if (Time.time - TimerCounter >= TimeToAttack && animator.GetInteger("EnemyHitValue")==0)
        {
            TimerCounter = Time.time;
            Debug.Log("pop");
            animator.SetInteger("EnemyAttack", 1);
        }
    }
}
