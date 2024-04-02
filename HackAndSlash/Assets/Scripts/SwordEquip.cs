using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordEquip : MonoBehaviour
{  
    
    public bool EquipTriggerHeavy;
    public bool EquipTriggerMid;
    Animator action;
    public Transform GreatSword, MidSword, Shelid;
    public Transform RightHand, LeftHand;
    public Transform GreatSwordParent, MidSwordParent, ShelidParent;
    public void GreatSwordPlacementToRightHand()
    {
        GreatSword.transform.parent = RightHand;
    }
    private void OnEnable()
    {
         action = GetComponent<Animator>();
    }
    public void SwordEquipAndUnEquip(InputAction.CallbackContext callbackContext)
    {
        EquipTriggerHeavy = !EquipTriggerHeavy;
        //action.SwordEquipTriggerGreatSword();
        //action.SwordEquipGreatSword(EquipTriggerHeavy);
        ////action.MeleeEquip(EquipTriggerHeavy);
        //action.SwordEquipMidSword(false);
        if(EquipTriggerHeavy)
        {
            action.CrossFade("Equip Great Sword ", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipGreatSword(true);
        }
        else
        {
            action.CrossFade("Unequip Great Sword ", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
        }
        PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
    } public void SwordEquipAndUnEquipMid(InputAction.CallbackContext callbackContext)
    {
        EquipTriggerMid = !EquipTriggerMid;
        //PlayerAnimations action=GetComponent<PlayerAnimations>();
        //action.SwordEquipTriggerGreatSword();
        //action.SwordEquipMidSword(EquipTriggerMid);
        //action.MeleeEquip(EquipTriggerMid);
        //action.SwordEquipGreatSword(false);
        if (EquipTriggerMid)
        {
            action.CrossFade("Draw Sword 2", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(true);
        }
        else
        {
            action.CrossFade("Draw Sword 2 0", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
        }
        PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
    }

}
