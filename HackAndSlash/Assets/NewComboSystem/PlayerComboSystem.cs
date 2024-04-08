using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComboSystem : MonoBehaviour
{
    public List<AttackData> comboDataHeavy;
    public List<AttackData> comboDataMid;
    public int comboCount;
    
    Animator animator;

    public bool playerRotate;
    float lastClickedTime;
    float lastComboEnd;
    //public float comboToEnd;
    //public float clickToEnd;
    // Start is called before the first frame update
    void Start()
    {
        animator = PlayerManger.instance.animationsInstance.playerAnime;
        //PlayerManger.instance.controllerInstance.playerInputActions.Player.Attack.started += Combo;
        //PlayerManger.instance.controllerInstance.PlayerActions += ExitAttack;
    }

    public void Combo(InputAction.CallbackContext callback)
    {
        CancelInvoke(nameof(ExitCombo));
        if(comboCount>comboDataHeavy.Count-1) {
            comboCount = 0;
        }
        Debug.LogError(lastComboEnd);
        if (Time.time - lastComboEnd > 0.8f && comboCount< comboDataHeavy.Count) 
        {
            Debug.LogError("combo");
            lastComboEnd = Time.time;
            if (Time.time-lastClickedTime>=0.5f)
            {
                Debug.LogError("click");
                StartCoroutine(PlayerComboAnimation(comboDataHeavy[comboCount]));
                comboCount++;
                lastClickedTime = Time.time;
                
            }
        }
    }
    IEnumerator PlayerComboAnimation(AttackData data)
    {
        PlayerManger.instance.controllerInstance.canMove = false;
        playerRotate = true;
        //animator.Play(data.AnimationName);
        animator.CrossFade(data.AnimationName, 0.2f);
        yield return new WaitForSeconds(0.8f);
        playerRotate = false;
        PlayerManger.instance.controllerInstance.canMove = true;
    }

    void ExitCombo()
    {
        comboCount = 0;
        lastComboEnd = Time.time;
      
    }
    public void ExitAttack()
    {
        if (animator.GetCurrentAnimatorStateInfo(1).length > 0.9 && animator.GetCurrentAnimatorStateInfo(1).IsTag("Attack"))
        {
            Debug.LogError("end"+lastComboEnd);
            Invoke(nameof(ExitCombo), 1.5f);
        }
    }
}
