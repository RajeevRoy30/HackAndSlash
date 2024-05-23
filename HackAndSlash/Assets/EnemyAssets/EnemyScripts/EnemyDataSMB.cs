using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDataSMB : StateMachineBehaviour
{
   [HideInInspector] public NavMeshAgent agent;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent=animator.transform.GetComponent<NavMeshAgent>();
    }
}
