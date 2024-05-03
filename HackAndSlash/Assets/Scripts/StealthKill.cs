using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StealthKill : MonoBehaviour
{
    [SerializeField]
    private float TakeDownOffset;
    public Transform enemyRef;
    public bool isTakeDown;

    //Scriptable Object
    public PLayerStealthAnimations StealthActions;
    public PLayerStealthAnimations BrutalAction;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.transform.CompareTag("Enemy"))
        {
           
            if (Input.GetKey(KeyCode.E))
            {

                enemyRef=other.transform.GetChild(0);
                //PlayerManger.instance.animationsInstance.TakeDownBrutalAnimation();
                StartCoroutine( PerformStealthAction(BrutalAction));
                other.GetComponent<Animator>().CrossFade(BrutalAction.AnimationName1, 0.2f);
                //Quaternion targetRot = Quaternion.Euler(0, other.transform.eulerAngles.y, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {

                //transform.LookAt(other.transform.GetChild(3).forward);
                //transform.parent.position = other.transform.GetChild(3).position;
                //PlayerManger.instance.animationsInstance.TakeDownStealthAnimation();


                //!!!!!!!try tomorrow 
                //other.transform.GetChild(0).localPosition = StealthActions.animPos;
                enemyRef = other.transform.GetChild(0);
                StartCoroutine(PerformStealthAction(StealthActions));
                 other.GetComponent<Animator>().CrossFade(StealthActions.AnimationName1, 0.2f);
            }
        }
        
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.transform.tag == "Enemy")
    //        enemyRef = null;
    //}

    private IEnumerator PerformStealthAction(PLayerStealthAnimations parkourAction)
    {
        Animator animator=transform.parent.GetComponent<Animator>();
        enemyRef.localPosition = parkourAction.animPos;
        isTakeDown = true;
       
        animator.CrossFade(parkourAction.AnimationName, 0.2f);
        
        //StartCoroutine(SetPlayerTarget())
        yield return null;

        var anim = animator.GetNextAnimatorStateInfo(0);
        //animator.applyRootMotion = true;
        //PlayerManger.instance.controllerInstance.canMove = false;
        animator.GetComponent<CharacterController>().enabled = false;
        StartCoroutine(SetPlayerTarget(parkourAction.animTime));
        
        if (!anim.IsName(parkourAction.AnimationName))
        {
            Debug.LogError("!Not valid Animation");
            isTakeDown = false;
        }
        yield return new WaitForSeconds(anim.length);
       
        //PlayerManger.instance.controllerInstance.canMove = true;
        animator.GetComponent<CharacterController>().enabled = true;
        //animator.applyRootMotion = false;
        isTakeDown = false;
    }
    IEnumerator SetPlayerTarget(float lerpDuration)
    {
        float timeElapsed = 0;
        Animator playerAnime = transform.parent.GetComponent<Animator>();
        while (timeElapsed < lerpDuration)
        {
            //Debug.Log("Hello");
            //transform.position = Vector3.Lerp(transform.position, PlayerManger.instance.stealthKillInstance.enemyRef.transform.position, timeElapsed / lerpDuration);
            //transform.rotation = Quaternion.Slerp(transform.rotation, PlayerManger.instance.stealthKillInstance.enemyRef.transform.rotation, timeElapsed / lerpDuration);
            //transform.parent.LookAt(PlayerManger.instance.stealthKillInstance.enemyRef.transform.position);
            //transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x, enemyRef.transform.eulerAngles.y, transform.parent.eulerAngles.z);
            //transform.LookAt(PlayerManger.instance.stealthKillInstance.enemyRef.transform.GetChild(3).position);
            //playerAnime.MatchTarget(enemyRef.transform.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).position, enemyRef.transform.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).rotation, AvatarTarget.Body, new MatchTargetWeightMask(new Vector3(0, 1, 1), 1), timeElapsed);
            Debug.LogError("OKOK");
            //transform.parent.LookAt(enemyRef.transform.forward);
            transform.parent.position = Vector3.Lerp(transform.parent.position, enemyRef.position,Time.deltaTime);
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, enemyRef.rotation, Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
