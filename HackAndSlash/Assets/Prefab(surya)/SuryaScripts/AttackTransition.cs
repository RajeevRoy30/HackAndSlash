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
    public LayerMask layerMask; // Select all layers that foot placement applies to.

    [Range(0, 1f)]
    public float DistanceToGround;
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
        if (animator)
        { // Only carry out the following code if there is an Animator set.

            // Set the weights of left and right feet to the current value defined by the curve in our animations.
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));

            // Left Foot
            RaycastHit hit;
            // We cast our ray from above the foot in case the current terrain/floor is above the foot position.
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {

                // We're only concerned with objects that are tagged as "Walkable"



                Vector3 footPosition = hit.point; // The target foot position is where the raycast hit a walkable object...
                footPosition.y += DistanceToGround; // ... taking account the distance to the ground we added above.
                animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(animator.transform.forward, hit.normal));



            }

            // Right Foot
            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {




                Vector3 footPosition = hit.point;
                footPosition.y += DistanceToGround;
                animator.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(animator.transform.forward, hit.normal));



            }


        }
    }
    void PerformDodge(Animator anim)
    {
        if (PlayerManger.instance.starterAssetsInputsInstance.inputActions.Player.Dodge.WasPressedThisFrame() && PlayerManger.instance.ThirdPersonControllerInstance._Dodge==false)
        {
            anim.SetTrigger("Dodge");
            PlayerManger.instance.ThirdPersonControllerInstance._Dodge=true;
        }
    }
}
