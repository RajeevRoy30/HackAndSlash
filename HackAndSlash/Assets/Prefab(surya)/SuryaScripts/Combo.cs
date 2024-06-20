using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combo : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    [SerializeField]float _keyFrameMin,_keyFrameMax;
    [SerializeField] bool _canReciveInput;
    int AnimComboID = Animator.StringToHash("ComboValue");
    [SerializeField] bool _canApplyRootMotion;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.applyRootMotion = true;
        //PlayerManager.Instance._ThirdPersonControllerInstance._canMove = false;
        PlayerManger.instance.ThirdPersonControllerInstance.canMove=false;
        //Debug.LogError("t");
        _canReciveInput=true;
        check=true;


    }
    [SerializeField] int _comboCount;
    //MonoBehaviour mono = new MonoBehaviour();
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    public int enemyHitCount;
    Vector3 Dir;
    Quaternion lookAt, temp;
    [SerializeField] float startMotion;
    [SerializeField] float swordDetectstart, swordDetectend;
    bool check;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // temp = PlayerManger.instance.combatSystemInstance.EnemyRef.position;
        //temp.y = animator.transform.position.y;
        //PlayerManger.instance.ThirdPersonControllerInstance.transform.transform.LookAt(temp);
        Vector3 direction = PlayerManger.instance.combatSystemInstance.EnemyRef.position - animator.transform.position;
        direction.y = 0; // Keep the rotation only in the horizontal plane
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            animator.rootRotation = Quaternion.Slerp(animator.rootRotation, lookRotation, Time.deltaTime * 5f); // Smooth the rotation
        }
        if (stateInfo.normalizedTime >= swordDetectstart && stateInfo.normalizedTime <= swordDetectend)
        {
            // Debug.LogError(enemyData.detect.ReturnCollider().gameObject.name);
            Debug.LogError("LOL");
            if (PlayerManger.instance.ThirdPersonControllerInstance.detect.ReturnCollider() != null && check)
            {
                check = false;
                if (PlayerManger.instance.ThirdPersonControllerInstance.detect.ReturnCollider().TryGetComponent(out Animator animatorREF))
                {
                    animatorREF.SetInteger("EnemyHit", 1);
                }
            }
        }
                    // Apply the root motion position from the animator
            animator.transform.position += animator.deltaPosition;



        if (PlayerManger.instance.starterAssetsInputsInstance.inputActions.Player.Attack.WasPressedThisFrame() && stateInfo.normalizedTime> _keyFrameMin && stateInfo.normalizedTime < _keyFrameMax && _canReciveInput)
        {
            
            _canReciveInput=false;
            animator.SetInteger(AnimComboID, _comboCount);
            //mono.StartCoroutine(Motion(stateInfo.length,animator));
            PlayerManger.instance.ThirdPersonControllerInstance.HitCount = enemyHitCount;
            //temp = animator.transform.position;
            //temp.y = PlayerManger.instance.combatSystemInstance.EnemyRef.position.y;
            // animator.transform.LookAt(Vector3.zero);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if(stateInfo.length>1)
       // animator.applyRootMotion = false;
        _canReciveInput = true;
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
