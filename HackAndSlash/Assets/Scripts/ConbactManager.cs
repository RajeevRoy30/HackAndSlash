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
       
    }
    void Start()
    {
        Move= GetComponent<PlayerMovemennt>();
        Move.inputs.Player.Attack.performed += Attack;
        
    }

    
    public void Attack(InputAction.CallbackContext context)
    {
         Debug.Log("hnicef");
        
        
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
