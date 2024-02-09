using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovemennt : MonoBehaviour

{
    public float value = 0;
    
    public Animator animations;
    HackAndSlash inputs;

    
    int Speed = 5;
    private void Awake()
    {
        inputs = new HackAndSlash();
        inputs.Player.Run.performed += Sprinting;
        inputs.Player.Run.canceled += ResetMethod;
        inputs.Player.Fire.performed += Slash;
        inputs.Player.Fire.canceled -= Slash; 
    }
    public Vector2 moveinput;
    public Vector3 movinginput;

   
    private void Update()
    {
        Movement();
        
    }
    public void Slash(InputAction.CallbackContext obj)
    {
        Debug.Log("attacked");
        animations.SetTrigger("IsAttacked");
        
    }
    public void Movement()
    {
        moveinput = inputs.Player.Move.ReadValue<Vector2>();
        movinginput.x = moveinput.x;
        movinginput.z = moveinput.y;

        if (moveinput.x != 0 || moveinput.y != 0)
        {
            if (value >= -1)
            {
                value += -1 * Time.deltaTime;
            }
            animations.SetFloat("XValue", value);
            animations.SetFloat("YValue", 0);
            transform.Translate(movinginput * Speed * Time.deltaTime);
            animations.SetBool("isWalking", true);

         
        }
        else
        {
            animations.SetBool("isWalking", false);

            if (value >= 0)
            {
               value += 1 * Time.deltaTime;
            }
        }

        Debug.Log(moveinput);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }


    private void OnDisable()
    {
        inputs.Disable();   
    }
    public void Sprinting(InputAction.CallbackContext obj)
    { 
      
        animations.SetBool("isRunning", true);

    }


    public void ResetMethod(InputAction.CallbackContext obj)
    {
        animations.SetBool("isRunning", false);
    }



}