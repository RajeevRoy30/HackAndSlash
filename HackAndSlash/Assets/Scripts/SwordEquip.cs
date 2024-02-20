using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordEquip : MonoBehaviour
{  
    
    public bool EquipTrigger;
    public void SwordEquipAndUnEquip(InputAction.CallbackContext callbackContext)
    {
        EquipTrigger = !EquipTrigger;
        PlayerAnimations action=GetComponent<PlayerAnimations>();
        action.SwordEquipTrigger();
        action.SwordEquip(EquipTrigger);
    }

}
