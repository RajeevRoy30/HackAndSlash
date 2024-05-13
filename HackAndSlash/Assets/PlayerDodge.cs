using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if(PlayerManger.instance.starterAssetsInputsInstance.move.x!=0|| PlayerManger.instance.starterAssetsInputsInstance.move.y != 0)
        //{
        //    animator.SetFloat("xInput", PlayerManger.instance.starterAssetsInputsInstance.move.x);
        //    animator.SetFloat("yInput", PlayerManger.instance.starterAssetsInputsInstance.move.y);
        //}
        //else
        //{
        //    animator.SetFloat("yInput", 1);
        //}
        animator.applyRootMotion = true;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerManger.instance.ThirdPersonControllerInstance._Dodge = false;
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
