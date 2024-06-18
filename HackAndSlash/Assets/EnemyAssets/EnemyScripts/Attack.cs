using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    EnemyData enemyData;
    [SerializeField]float swordDetectstart, swordDetectend;
    [SerializeField] int comboCount,HitValue;
    [SerializeField] bool check;
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
        if (enemyData == null && animator.TryGetComponent(out EnemyData enemy))
        {
            enemyData = enemy;
        }
        enemyData.hitValue = HitValue;
        check = true;
        //animator.transform.GetComponent<NavMeshAgent>().enabled=false;

    }
    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SwordDetect(stateInfo);
        if(EnemyHolder.instance.CalculateDistance(animator.transform.position)<=1.5f)
            animator.SetInteger("EnemyAttack", comboCount);
        else
            animator.SetInteger("EnemyAttack", 0);
        
    }

    public void SwordDetect(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.normalizedTime >= swordDetectstart && stateInfo.normalizedTime <= swordDetectend)
        {
            Debug.LogError(enemyData.detect.SwordDetectEnemy().gameObject.name);
            Debug.LogError("LOL");
            if (enemyData.detect.SwordDetectEnemy() != null && check)
            {
                check = false;
                if (enemyData.detect.SwordDetectEnemy().TryGetComponent(out Animator animatorREF))
                {
                    animatorREF.SetInteger("HitValue", enemyData.hitValue);
                    Debug.Log(enemyData.hitValue);
                }
            }
        }
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
