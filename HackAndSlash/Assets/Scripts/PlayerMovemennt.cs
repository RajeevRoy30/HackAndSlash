using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovemennt : MonoBehaviour

{
    PlayerAnimations animations;
    public Animator Anim;

    SwordEquip equip;
    public ConbactManager combat;

    public float value = 0;
    
    public HackAndSlash inputs;

    
    int Speed = 5;
    private void Awake()
    {
        equip=GetComponent<SwordEquip>();
        animations = GetComponent<PlayerAnimations>();
        inputs = new HackAndSlash();
        inputs.Player.Run.performed += Sprinting;
        inputs.Player.Run.canceled += ResetMethod;
        inputs.Player.SwordEquip.performed+= equip.SwordEquipAndUnEquip;
        //inputs.Player.Fire.performed += Slash;
        //inputs.Player.Fire.canceled -= Slash; 

        //inputs.Player.Attack.performed += AttackMethod;



    }
    public Vector2 moveinput;
    public Vector3 movinginput;
    public float animeValue, walkAnimeValue = 0.5f, runAnimeValue = 1f;
   
    private void Update()
    {
        Movement();
        
    }

    public void AttackMethod(InputAction.CallbackContext context)
    {
        Debug.Log("hnicef");
        if (context.performed)
        {
            Anim.SetTrigger("Attack1");
        }
    }

    public void Slash(InputAction.CallbackContext obj)
    {
        Debug.Log("attacked");
        //animations.SetTrigger("IsAttacked");
        
    }
    public void Movement()
    {
        moveinput = inputs.Player.Move.ReadValue<Vector2>();
        movinginput.x = moveinput.x;
        movinginput.z = moveinput.y;
        


        if(inputs.Player.Run.IsPressed())
        {
            animeValue = runAnimeValue;

           
        }
        else
        {
            animeValue = walkAnimeValue;
        }
        
        animations.MovementAnimation(moveinput.x*animeValue,moveinput.y*animeValue);

        //if (moveinput.x != 0 || moveinput.y != 0)
        //{
        //    if (value >= -1)
        //    {
        //        value += -1 * Time.deltaTime;
        //    }
        //    animations.SetFloat("Xvalue", value);
        //    animations.SetFloat("Yvalue", 0);
        //    transform.Translate(movinginput * Speed * Time.deltaTime);
        //    animations.SetBool("isWalking", true);


        //}
        //    else
        //    {
        //        animations.SetBool("isWalking", false);

        //        if (value >= 0)
        //        {
        //           value += 1 * Time.deltaTime;
        //        }
        //    }

        //    Debug.Log(moveinput);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }


    private void OnDisable()
    {
       // inputs.Disable();   
    }
    public void Sprinting(InputAction.CallbackContext obj)
    { 
      
        animeValue=runAnimeValue;
        Debug.Log("running");

    }


    public void ResetMethod(InputAction.CallbackContext obj)
    {
        animeValue = walkAnimeValue;
        //Debug.Log("not running");
    }



}