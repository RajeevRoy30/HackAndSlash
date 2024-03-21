using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthKill : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if (Input.GetKey(KeyCode.K))
            {
                PlayerManger.instance.animationsInstance.TakeDownAnimation();
                other.GetComponent<Animator>().SetTrigger("TakeDownDie");
            }
        }
    }
}
