using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    PlayerAnimations animations;

    SwordEquip equip;


    public float value = 0;

    public HackAndSlash inputs;

    private CharacterController characterController;


    int Speed = 5;
    private void Awake()
    {
        equip = GetComponent<SwordEquip>();
        animations = GetComponent<PlayerAnimations>();
        characterController = GetComponent<CharacterController>();
        inputs = new HackAndSlash();
        inputs.Player.Run.performed += Sprinting;
        inputs.Player.Run.canceled += ResetMethod;
        inputs.Player.SwordEquip.performed += equip.SwordEquipAndUnEquip;
        //inputs.Player.Fire.performed += Slash;
        //inputs.Player.Fire.canceled -= Slash; 
        
    }
    public Vector2 moveinput;
    public Vector3 movinginput;
    public float runSpeed;
    public float walkSpeed;
    private float playerSpeed;
    public Vector3 direction;
    public float animeValue, walkAnimeValue = 0.5f, runAnimeValue = 1f;

    private void Update()
    {
        Movement();

    }
    public void Slash(InputAction.CallbackContext obj)
    {
        Debug.Log("attacked");
        //animations.SetTrigger("IsAttacked");

    }
    public float y;
    public void Movement()
    {
        moveinput = inputs.Player.Move.ReadValue<Vector2>();
        movinginput.x = moveinput.x;
        movinginput.z = moveinput.y;
        //direction = new Vector3(moveinput.x * playerSpeed, y, moveinput.y * playerSpeed);

        Vector3 camForward = transform.InverseTransformVector(Camera.main.transform.forward);
        Vector3 camRight = transform.InverseTransformVector(Camera.main.transform.right);
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        Vector3 relativeHorizontal = moveinput.y * camForward;
        Vector3 relativeVertical = moveinput.x * camRight;
        direction = (relativeHorizontal + relativeVertical) * playerSpeed;
        Vector3 curPos = transform.position;
        Vector3 newPos = new Vector3(movinginput.x, 0, moveinput.y);
        Vector3 rotPos = curPos + newPos;
        transform.LookAt(rotPos);
        characterController.Move(direction * Time.deltaTime);


        if (inputs.Player.Run.IsPressed())
        {
            animeValue = runAnimeValue;
            playerSpeed = runSpeed;


        }
        else
        {
            animeValue = walkAnimeValue;
            playerSpeed = walkSpeed;
        }

        animations.MovementAnimation(moveinput.x * animeValue, moveinput.y * animeValue);


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

        animeValue = runAnimeValue;
        Debug.Log("running");

    }


    public void ResetMethod(InputAction.CallbackContext obj)
    {
        animeValue = walkAnimeValue;
        //Debug.Log("not running");
    }


}