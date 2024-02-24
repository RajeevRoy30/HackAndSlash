using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParkourSystem : MonoBehaviour
{
    [Header("obstical Detect")]
    public LayerMask ObsticalMaskLayer;
    public float parkourRayLength;
    public float heightRayLength;
    public Vector3 playerOffSet;
    public Vector3 playerAnimationOffset;
    private PlayerMovemennt Player;

  

    public List<ParkourAction> parkourActions;

   
    public Transform t;
    public Animator animator;
    public bool playerInAction;
    CharacterController c;
    private void Start()
    {
        c= GetComponent<CharacterController>();
        Player=GetComponent<PlayerMovemennt>();
        Player.inputs.Player.Jump.started += PlayerAnimation;
    }
    private void Update()
    {
        //EnvironmentDetection();
        //Just();
       // Help();
       
    }

    //animatons working
    //void Help()
    //{
    //    var hitinfo = EnvironmentDetection();
    //    if (hitinfo.hitFound && !playerInAction)
    //    {
    //        foreach (var action in parkourActions)
    //        {
    //            if (action.CheckForAnim(hitinfo, transform))
    //            {
    //                ///
    //                StartCoroutine(PerformParkourAnimation(action));
    //                break;
    //            }
    //        }
    //    }
    //}
    void PlayerAnimation(InputAction.CallbackContext callback)
    {
        var hitinfo=EnvironmentDetection();
        if(hitinfo.hitFound && !playerInAction)
        {
            foreach(var action in parkourActions)
            {
                if(action.CheckForAnim(hitinfo, transform))
                {
                    ///
                    StartCoroutine(PerformParkourAnimation(action));
                    break;
                }
            }
        }
    }
    IEnumerator PerformParkourAnimation(ParkourAction parkourAction)
    {
        playerInAction = true;
        animator.CrossFade(parkourAction.AnimationName, 0.2f);
        yield return null;

        var anim=animator.GetNextAnimatorStateInfo(0);
        animator.applyRootMotion = true;
        c.enabled = false;
        if(!anim.IsName(parkourAction.AnimationName))
        {
            Debug.Log("Not valid Animation");
        }
        yield return new WaitForSeconds(anim.length);
        c.enabled = true;
        animator.applyRootMotion = false;
        playerInAction =false;
    }
    //
    Vector3 temp;
    
    public HitInfo EnvironmentDetection()//Detect the environment 
    {
        var hitInfo=new HitInfo();
        var parkourRay = transform.position + playerOffSet;
        hitInfo.hitFound = Physics.Raycast(parkourRay, transform.forward, out hitInfo.parkourHit, parkourRayLength, ObsticalMaskLayer);
        Debug.DrawRay(parkourRay, transform.forward * parkourRayLength, (hitInfo.hitFound) ? Color.red : Color.green);
        if (hitInfo.hitFound)
        {
            var heightRay = hitInfo.parkourHit.point + Vector3.up * heightRayLength;
            hitInfo.heightFound = Physics.Raycast(heightRay, Vector3.down, out hitInfo.heightHit, heightRayLength, ObsticalMaskLayer);
            Debug.DrawRay(heightRay, Vector3.down * heightRayLength, (hitInfo.heightFound) ? Color.blue : Color.red);

            // playerAnimationOffset.y = hitInfo.heightHit.point.y;
            //playerAnimationOffset.z = (hitInfo.parkourHit.transform.localScale.z / 2)+ (hitInfo.parkourHit.distance/2);
            //temp= hitInfo.heightHit.point + playerAnimationOffset;
            //MainPos.position = Vector3.Lerp(MainPos.position, temp, Time.deltaTime);
            //t.position = Vector3.Lerp(t.position, temp, Time.deltaTime);
           // c.Move(temp);
        }

        return hitInfo;
    }

  
    public void Just(InputAction.CallbackContext callback)
    {
        var hitInfo = new HitInfo();
        var parkourRay = transform.position + playerOffSet;
        hitInfo.hitFound = Physics.Raycast(parkourRay, transform.forward, out hitInfo.parkourHit, parkourRayLength, ObsticalMaskLayer);
        Debug.DrawRay(parkourRay, transform.forward * parkourRayLength, (hitInfo.hitFound) ? Color.red : Color.green);
        if (hitInfo.hitFound)
        {
            if (hitInfo.parkourHit.transform.TryGetComponent(out MeshRenderer mesh))
            {
                Debug.Log(mesh.bounds.size);
            }
        }
    }
   
}
public struct HitInfo
{
    public bool hitFound;
    public bool heightFound;
    public RaycastHit parkourHit;
    public RaycastHit heightHit;
}

