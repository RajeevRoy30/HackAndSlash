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
        controllerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        conbactManagerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<ConbactManager>();
        animationsInstance = GameObject.FindGameObjectWithTag("Player").GetComponent <PlayerAnimations>();
        swordEquipInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<SwordEquip>();
        parkourSystemInstance= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParkourSystem>();
        comboSystemInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComboSystem>();
        stealthKillInstance = GameObject.Find("StealthKill").GetComponent<StealthKill>();
    }
}
