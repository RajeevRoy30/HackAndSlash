using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour

{
    // Start is called before the first frame update
    [HideInInspector]
    public  Animator playerAnime;
    public float dampValue;

    private void Awake()
    {
        playerAnime = GetComponent<Animator>(); 
    }
    public void MovementAnimation(float Xvalue,float Yvalue)
    {
        //float x, y;
        //x = playerAnime.GetFloat("XValue");
        //y = playerAnime.GetFloat("YValue");

        //Xvalue = Mathf.Lerp(x, Xvalue, 0.45f);
        //Yvalue = Mathf.Lerp(y, Yvalue, 0.45f);





        playerAnime.SetFloat("XValue", Xvalue, dampValue, Time.deltaTime);
        playerAnime.SetFloat("YValue", Yvalue, dampValue, Time.deltaTime);
        
    }
    public void SwordEquipGreatSword(bool Sword)
    {
        playerAnime.SetBool("GreatSword", Sword);
    }public void SwordEquipMidSword(bool Sword)
    {
        playerAnime.SetBool("MidSword", Sword);
    }
    //public void SwordEquipTriggerGreatSword()
    //{
    //    playerAnime.SetTrigger("EquipTrigger");
    //}
    //public void MeleeEquip(bool equip)
    //{
    //    playerAnime.SetBool("Equip",equip);
    //}

    public void AttackAnimOn()
    {
        ////Debug.LogError("On");
        ////characterController.enabled=false;
        //PlayerManger.instance.controllerInstance.canMove = false;
        //playerAnime.applyRootMotion = true;
    }
    public void AttackAnimOff()
    {
        //Debug.LogError("Off");
        //characterController.enabled = true;
        //PlayerManger.instance.controllerInstance.canMove = true;
        //playerAnime.applyRootMotion = false;
    }
    public void PlayerBlockUp(InputAction.CallbackContext context)
    {
        if (!PlayerManger.instance.controllerInstance.playerInputActions.Player.Run.IsPressed())
        {
            playerAnime.SetBool("Block", true);
        }
    }
    public void PlayerBlockDown(InputAction.CallbackContext context)
    {
        playerAnime.SetBool("Block", false);
    }

    public void TakeDownBrutalAnimation()
    {
        playerAnime.SetTrigger("TakeDownBack");
    }
    public void TakeDownStealthAnimation()
    {
        playerAnime.SetTrigger("TakeDownStealth");
    }
    public void PlayerRoll(InputAction.CallbackContext context)
    {
        if(!PlayerManger.instance.parkourSystemInstance.EnvironmentDetection().hitFound)
            playerAnime.SetTrigger("Roll");
    }

    //character controller setting throug events
    public void SetCharacterController(float size)
    {
        playerAnime.transform.GetComponent<CharacterController>().height = size;
    }
    //public void SetCharacterControllerRadius(float size)
    //{
    //    playerAnime.transform.GetComponent<CharacterController>().radius = size;
    //}
    //public void characterControllerOn()
    //{
    //    playerAnime.transform.GetComponent<CharacterController>().enabled=true;
    //    PlayerManger.instance.stealthKillInstance.enemyRef.transform.GetComponent<Collider>().enabled=true;
    //}
    //public void characterControllerOff()
    //{
    //    playerAnime.transform.GetComponent<CharacterController>().enabled = false;
    //    PlayerManger.instance.stealthKillInstance.enemyRef.transform.GetComponent<Collider>().enabled = false;
    //}
    //public void SetPlayerStealthAttackPos()
    //{
    //    if (PlayerManger.instance.stealthKillInstance.enemyRef != null)
    //    {
    //        Debug.LogError("Stealth kill");
    //        //transform.LookAt(PlayerManger.instance.stealthKillInstance.enemyRef.transform.GetChild(3).forward);
    //        ////transform.rotation = PlayerManger.instance.stealthKillInstance.enemyRef.transform.rotation;
    //        //transform.position = PlayerManger.instance.stealthKillInstance.enemyRef.transform.GetChild(3).position;
    //        StartCoroutine(SetPlayerPosition(3));
    //    }

    //}
   
}
