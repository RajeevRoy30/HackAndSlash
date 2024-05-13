using Invector.vCharacterController;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
   public static PlayerManger instance;

    [Header("Player Scripts")]
    public PlayerController controllerInstance;
    public ConbactManager conbactManagerInstance;
    public PlayerAnimations animationsInstance;
    public SwordEquip swordEquipInstance;
    public PlayerParkourSystem parkourSystemInstance;
    public StealthKill stealthKillInstance;
    public PlayerComboSystem comboSystemInstance;

    public ThirdPersonController ThirdPersonControllerInstance;
    public StarterAssetsInputs starterAssetsInputsInstance;
    public SwordDetection SwordDetectionInstance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        ThirdPersonControllerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        starterAssetsInputsInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssetsInputs>();
        swordEquipInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<SwordEquip>();
        controllerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        conbactManagerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<ConbactManager>();
        animationsInstance = GameObject.FindGameObjectWithTag("Player").GetComponent <PlayerAnimations>();
        parkourSystemInstance= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParkourSystem>();
        comboSystemInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComboSystem>();
        stealthKillInstance = GameObject.Find("StealthKill").GetComponent<StealthKill>();
    }
}
