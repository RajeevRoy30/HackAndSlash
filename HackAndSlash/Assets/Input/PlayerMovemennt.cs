using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovemennt : MonoBehaviour

{ 

    
    public Animator animations;
    HackAndSlash inputs;

    
    int Speed = 5;
    private void Awake()
    {
        inputs = new HackAndSlash();
    }
    public Vector2 moveinput;
    public Vector3 movinginput;
   
    private void Update()
    {
        moveinput = inputs.Player.Move.ReadValue<Vector2>();
        movinginput.x = moveinput.x;
        movinginput.z = moveinput.y;

        if (moveinput.x != 0 || moveinput.y != 0)
        {
            transform.Translate(movinginput * Speed * Time.deltaTime);
            animations.SetBool("isWalking", true);


        }
        else
        {
            animations.SetBool("isWalking", false);
          

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
    
}