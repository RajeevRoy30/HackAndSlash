using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class SwordEquip : MonoBehaviour
{  
    
    public bool EquipTriggerHeavy;
    public bool EquipTriggerMid;
    
    public void SwordEquipAndUnEquip(InputAction.CallbackContext callbackContext)
    {
        EquipTriggerHeavy = !EquipTriggerHeavy;
        //action.SwordEquipTriggerGreatSword();
        //action.SwordEquipGreatSword(EquipTriggerHeavy);
        ////action.MeleeEquip(EquipTriggerHeavy);
        //action.SwordEquipMidSword(false);
        if(EquipTriggerHeavy)
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Equip Great Sword ", 0.2f);
            PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
            PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
            PlayerManger.instance.animationsInstance.SwordEquipGreatSword(true);
        }
        else
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Unequip Great Sword ", 0.2f);
            PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started -= PlayerManger.instance.comboSystemInstance.Combo;
            PlayerManger.instance.controllerInstance.PlayerActions -= PlayerManger.instance.comboSystemInstance.ExitAttack;
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
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(true);
        }
        else
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2 0", 0.2f);
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
        }
        PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
    }

}
