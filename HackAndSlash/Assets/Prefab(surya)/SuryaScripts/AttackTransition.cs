using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("ComboValue", 0);
        animator.applyRootMotion = false;
        PlayerManger.instance.ThirdPersonControllerInstance.canMove = true;
        //PlayerManger.instance.controllerInstance._swordCollider.enabled=false;
        PlayerManger.instance.ThirdPersonControllerInstance.HitCount = 0;
    }
    [SerializeField] int _comboCount;
    Vector2 evadeValue;
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(PlayerManger.instance.starterAssetsInputsInstance.inputActions.Player.Attack.WasPressedThisFrame())
        {
            animator.SetInteger("ComboValue", _comboCount);
        }
        PerformDodge(animator);



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
    void PerformDodge(Animator anim)
    {
        if (PlayerManger.instance.starterAssetsInputsInstance.inputActions.Player.Dodge.WasPressedThisFrame() && PlayerManger.instance.ThirdPersonControllerInstance._Dodge==false)
        {
            anim.SetTrigger("Dodge");
            PlayerManger.instance.ThirdPersonControllerInstance._Dodge=true;
        }
    }
}
