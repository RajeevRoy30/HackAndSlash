using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour

{
    // Start is called before the first frame update
   private  Animator playerAnime;
    public float dampValue;
    public CharacterController characterController;

    private void Awake()
    {
        playerAnime = GetComponent<Animator>(); 
    }
    public void MovementAnimation(float Xvalue,float Yvalue)
    {
        float x, y;
        //x = playerAnime.GetFloat("XValue");
        //y = playerAnime.GetFloat("YValue");

        //Xvalue = Mathf.Lerp(x, Xvalue, 0.45f);
        //Yvalue = Mathf.Lerp(y, Yvalue, 0.45f);





        playerAnime.SetFloat("XValue", Xvalue, dampValue, Time.deltaTime);
        playerAnime.SetFloat("YValue", Yvalue, dampValue, Time.deltaTime);
        
    }
    public void SwordEquip(bool Sword)
    {
        playerAnime.SetBool("Equip",Sword);
    }
    public void SwordEquipTrigger()
    {
        playerAnime.SetTrigger("EquipTrigger");
    }

    public void AttackAnimOn()
    {
        Debug.LogError("On");
        characterController.enabled=false;
        playerAnime.applyRootMotion = true;
    }
    public void AttackAnimOff()
    {
        Debug.LogError("Off");
        characterController.enabled = true;
        playerAnime.applyRootMotion = false;
    }
    public void PlayerBlockUp(InputAction.CallbackContext context)
    {
        playerAnime.SetBool("Block", true);
    }
    public void PlayerBlockDown(InputAction.CallbackContext context)
    {
        playerAnime.SetBool("Block", false);
    }
}
