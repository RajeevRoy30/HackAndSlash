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
        if(EquipTriggerMid) 
        {
            StartCoroutine(SwitchToMidToHeavy(0.8f));
        }
        else
        {
            HeavySwordCondition(EquipTriggerHeavy);
        }

        //action.SwordEquipTriggerGreatSword();
        //action.SwordEquipGreatSword(EquipTriggerHeavy);
        ////action.MeleeEquip(EquipTriggerHeavy);
        //action.SwordEquipMidSword(false);
        // if(EquipTriggerHeavy)
        // {
        //PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Equip Great Sword ", 0.2f);
        //PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
        //PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
        //PlayerManger.instance.comboSystemInstance.Temp = PlayerManger.instance.comboSystemInstance.comboDataHeavy;
        //PlayerManger.instance.animationsInstance.SwordEquipGreatSword(true);
        //StartCoroutine(SetSwordToHandHeavySword(0.2f));

        // }
        // else
        //{
        //PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Unequip Great Sword ", 0.2f);
        //PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started -= PlayerManger.instance.comboSystemInstance.Combo;
        //PlayerManger.instance.controllerInstance.PlayerActions -= PlayerManger.instance.comboSystemInstance.ExitAttack;
        ////PlayerManger.instance.comboSystemInstance.Temp.Clear();
        //PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
        //StartCoroutine(SetSwordToShethHeavySword(0.2f));
        // }
        // PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
    } 
    public void SwordEquipAndUnEquipMid(InputAction.CallbackContext callbackContext)
    {
        EquipTriggerMid = !EquipTriggerMid;
        if(EquipTriggerHeavy) 
        {
            StartCoroutine(SwitchToHeavyToMid(0.8f));
        }
        else
        {
            MidSwordCondition(EquipTriggerMid);
        }
        //PlayerAnimations action=GetComponent<PlayerAnimations>();
        //action.SwordEquipTriggerGreatSword();
        //action.SwordEquipMidSword(EquipTriggerMid);
        //action.MeleeEquip(EquipTriggerMid);
        //action.SwordEquipGreatSword(false);
        //if (EquipTriggerMid)
        //{
        //        PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2", 0.2f);
        //        PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
        //        PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
        //        PlayerManger.instance.comboSystemInstance.Temp = PlayerManger.instance.comboSystemInstance.comboDataMid;
        //        PlayerManger.instance.animationsInstance.SwordEquipMidSword(true);
        //        StartCoroutine(SetSwordToHandMid(0.2f));
        // }
        //else
        //{
        //    PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2 0", 0.2f);
        //    PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
        //    PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
        //    //PlayerManger.instance.comboSystemInstance.Temp.Clear();
        //    PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
        //    StartCoroutine(SetSwordToShethMid(0.2f));
        // }
        PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
    }

    void HeavySwordCondition(bool condition)
    {
        if(condition) {
        PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Equip Great Sword ", 0.2f);
        PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
        PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
        PlayerManger.instance.comboSystemInstance.Temp = PlayerManger.instance.comboSystemInstance.comboDataHeavy;
        PlayerManger.instance.animationsInstance.SwordEquipGreatSword(true);
        StartCoroutine(SetSwordToHandHeavySword(0.2f));
        }
        else
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Unequip Great Sword ", 0.2f);
            PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started -= PlayerManger.instance.comboSystemInstance.Combo;
            PlayerManger.instance.controllerInstance.PlayerActions -= PlayerManger.instance.comboSystemInstance.ExitAttack;
            //PlayerManger.instance.comboSystemInstance.Temp.Clear();
            PlayerManger.instance.animationsInstance.SwordEquipGreatSword(false);
            StartCoroutine(SetSwordToShethHeavySword(0.2f));
        }
    }
    void MidSwordCondition(bool condition)
    {
        if (condition)
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2", 0.2f);
            PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
            PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
            PlayerManger.instance.comboSystemInstance.Temp = PlayerManger.instance.comboSystemInstance.comboDataMid;
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(true);
            StartCoroutine(SetSwordToHandMid(0.2f));
        }
        else
        {
            PlayerManger.instance.animationsInstance.playerAnime.CrossFade("Draw Sword 2 0", 0.2f);
            PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += PlayerManger.instance.comboSystemInstance.Combo;
            PlayerManger.instance.controllerInstance.PlayerActions += PlayerManger.instance.comboSystemInstance.ExitAttack;
            //PlayerManger.instance.comboSystemInstance.Temp.Clear();
            PlayerManger.instance.animationsInstance.SwordEquipMidSword(false);
            StartCoroutine(SetSwordToShethMid(0.2f));
        }
    }

    IEnumerator SwitchToHeavyToMid(float time)
    {
        HeavySwordCondition(false);
        EquipTriggerHeavy = false;
        yield return new WaitForSeconds(time);
        MidSwordCondition(true);
    }
    IEnumerator SwitchToMidToHeavy(float time)
    {
        MidSwordCondition(false);
        EquipTriggerMid=false;
        yield return new WaitForSeconds(time);
        HeavySwordCondition(true);
    }


    [Header("Sword Equip and Unequip IK")]
    public MultiParentConstraint GreatSwordEquipAndUnequip;
    public MultiParentConstraint MidSwordEquipAndUnequip;
    public MultiParentConstraint MidSheildEquipAndUnequip;
    public WeightedTransformArray a;
    IEnumerator SetSwordToHandHeavySword(float time)
    {
        yield return new WaitForSeconds(time);
        a = GreatSwordEquipAndUnequip.data.sourceObjects;
        a.SetWeight(0, 0f);
        a.SetWeight(1, 1f);
        GreatSwordEquipAndUnequip.data.sourceObjects = a;
    }
    IEnumerator SetSwordToShethHeavySword(float time)
    {
        yield return new WaitForSeconds(time);
        //a = GreatSwordEquipAndUnequip.data.sourceObjects;
        a.SetWeight(0, 1f);
        a.SetWeight(1, 0f);
        a.Clear();
        GreatSwordEquipAndUnequip.data.sourceObjects = a;
    }


    //Mid Sword 
    IEnumerator SetSwordToHandMid(float time)
    {
        yield return new WaitForSeconds(time);
        a = MidSwordEquipAndUnequip.data.sourceObjects;
        a = MidSheildEquipAndUnequip.data.sourceObjects;
        a.SetWeight(0, 0f);
        a.SetWeight(1, 1f);
        MidSwordEquipAndUnequip.data.sourceObjects = a;
        MidSheildEquipAndUnequip.data.sourceObjects = a;
    }
    IEnumerator SetSwordToShethMid(float time)
    {
        yield return new WaitForSeconds(time);
        //a = MidSwordEquipAndUnequip.data.sourceObjects;
        a.SetWeight(0, 1f);
        a.SetWeight(1, 0f);
        a.Clear();
        MidSwordEquipAndUnequip.data.sourceObjects = a;
        MidSheildEquipAndUnequip.data.sourceObjects = a;
    }
}
