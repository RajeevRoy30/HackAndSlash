using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConbactManager : MonoBehaviour
{
    public static ConbactManager instance;

    public bool canRecieveInput;
    
    public bool inputRecieved;
    HackAndSlash input;

    public Animator Anim;

    public PlayerMovemennt Move;
   
    // Start is called before the first frame update

    public void Awake()
    {
        instance = this;
        input=new HackAndSlash();
       
    }
    void Start()
    {
        //PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += Attack;
        PlayerManger.instance.controllerInstance.playerInputActions.Player.Block.started += PlayerManger.instance.animationsInstance.PlayerBlockUp;
        PlayerManger.instance.controllerInstance.playerInputActions.Player.Block.canceled += PlayerManger.instance.animationsInstance.PlayerBlockDown;
    }

    
    public void Attack(InputAction.CallbackContext context)
    {
            if(canRecieveInput)
            {
                inputRecieved = true;
                canRecieveInput = false;
               // Anim.SetTrigger("Attack1");
            }
            else
            {
                return;
            }
        
    }


    public void InputManager()
    {
       canRecieveInput=!canRecieveInput;
    }

    

}
