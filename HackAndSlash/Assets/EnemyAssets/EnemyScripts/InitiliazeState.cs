using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InitiliazeState : StateMachineBehaviour
{
    public EnemyData enemyDataPop;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.enemyDataPop=animator.transform.GetComponent<EnemyData>();
    }
}
