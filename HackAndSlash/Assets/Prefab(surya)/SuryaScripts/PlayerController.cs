using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerWalkSpeed = 5;
    [SerializeField] private float playerRunSpeed = 10;
    [SerializeField] private float playerCrouchSpeed = 3.0f;
    //[SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    //public PlayerInput playerInput;
    PlayerAnimations animations;
    Transform cameraTransform;
    [SerializeField] private float rotSpeed;

    private InputAction moveAction;
    private InputAction runAction;
    private InputAction crouchAction;
    private bool isRUnning;
    private bool isCrouching;
    //private InputAction jumpAction;
   
    private float playerHeight;


    public UnityAction PlayerActions;
    public Transform PlayerAimAt;
   
    public Vector2 input;
    private Vector3 move;

    //Surya Code
    public HackAndSlash playerInputActions;
    public float animeValue;

    public CinemachineVirtualCamera virtualCam;
    public Transform crouchCamPos;
    private Transform intialPos;
    private void Awake()
    {
        playerInputActions = new HackAndSlash();
    }
    private void Start()
    {
        intialPos = transform;
        playerInputActions.Enable();
        playerInputActions.Player.Run.started += PlayerRunPressed;
        playerInputActions.Player.Run.canceled += PlayerRunReleased;
        playerInputActions.Player.SwordEquip.started += PlayerManger.instance.swordEquipInstance.SwordEquipAndUnEquip;
        animations =GetComponent<PlayerAnimations>();
        playerSpeed = playerWalkSpeed;
        animeValue = 0.5f;
        controller = GetComponent<CharacterController>();
        playerHeight = controller.height;
        cameraTransform=Camera.main.transform;
        isCrouching = false;
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        
        PlayerActions += Movement;
        
    }
    void CrouchPressed(InputAction.CallbackContext callback)
    {
            virtualCam.LookAt = crouchCamPos;
            virtualCam.Follow = crouchCamPos;
          //  PlayerManager.instance.actions.CrouchBool(true);
        //playerSpeed = Mathf.Lerp(playerSpeed, playerCrouchSpeed, 0.5f);
            playerSpeed = playerCrouchSpeed;
           // PlayerManager.instance.actions.CrouchMovement(input.y * 0.3f, input.x * 0.3f);
    }
    void CrouchReleased(InputAction.CallbackContext callback)
    {
        virtualCam.LookAt = intialPos;
        virtualCam.Follow = intialPos;
        playerSpeed = playerWalkSpeed;
       // PlayerManager.instance.actions.CrouchBool(false);
        controller.height = playerHeight;
        //playerSpeed = 5f;
        //GameManager.Instance.actionAnim.Walk();
        return;
    }
    public Transform playerHeadTransform;
    public float aimDistance;
    public void AimAt()
    {

        //if (Physics.Raycast(playerHeadTransform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity, PlayerManager.instance.shootInstance.shootMask))
        //{
        //    if(hit.distance<aimDistance)
        //    {
        //        Debug.Log("dfyeguhds");
        //    PlayerAimAt.position = hit.point;
        //    Debug.DrawRay(playerHeadTransform.position, Camera.main.transform.forward * hit.distance, Color.green);
        //    }
        //    else
        //    {
        //        PlayerAimAt.position = playerHeadTransform.position + Camera.main.transform.forward * 20;
        //        Debug.DrawRay(playerHeadTransform.position, Camera.main.transform.forward * 50f, Color.red);
        //    }
        //}
        //else
        //{
            PlayerAimAt.position = playerHeadTransform.position + Camera.main.transform.forward * 20;
            Debug.DrawRay(playerHeadTransform.position, Camera.main.transform.forward * 50f, Color.red);
        //}
    }
    void Update()
    {
        PlayerActions?.Invoke();
        
    }
    void Movement()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        //if (jumpAction.triggered && groundedPlayer)
        //{
        //    GameManager.Instance.actionAnim.Jump();
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        input = playerInputActions.Player.Move.ReadValue<Vector2>();
        move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //isRUnning = runAction.ReadValue<float>() > .1f;

        //if (isRUnning)
        //{
        //    animValue = 0.6f;
        //    playerSpeed = Mathf.Lerp(playerSpeed,playerRunSpeed,0.5f);
        //}
        //else
        //{
        //    animValue = 0.3f;
        //    playerSpeed = Mathf.Lerp(playerSpeed, playerWalkSpeed, 0.5f);
        //}


        //rotation towards cam dir
        // PlayerManager.instance.actions.Movement(input.y * animValue, input.x * animValue);
        animations.MovementAnimation(input.x * animeValue, input.y * animeValue);
        if (input.x!=0||input.y!=0)
        {
            Quaternion targetRot = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
       

    }
    
    void PlayerRunPressed(InputAction.CallbackContext callback)
    {
        animeValue = 1.0f;
        //playerSpeed = Mathf.Lerp(playerSpeed, playerRunSpeed, 0.5f);
        //PlayerManager.instance.actions.Run(true);
        playerSpeed = playerRunSpeed;
    }

    void PlayerRunReleased(InputAction.CallbackContext callback) 
    {
        animeValue = 0.5f;
        playerSpeed = playerWalkSpeed;
        //PlayerManager.instance.actions.Run(false);
        // playerSpeed = Mathf.Lerp(playerSpeed, playerWalkSpeed, 0.5f);
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
        PlayerActions -= Movement;

        playerInputActions.Player.Run.started -= PlayerRunPressed;
        playerInputActions.Player.Run.canceled -= PlayerRunReleased;
      
        ObjectPreview obj = new ObjectPreview();
        obj.Cleanup();
    }
}