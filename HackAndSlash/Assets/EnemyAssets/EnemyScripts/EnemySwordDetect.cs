using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordDetect : MonoBehaviour
{
    public Collider detect;
    private void OnEnable()
    {
        detect = GetComponent<Collider>();
    }
    [SerializeField] LayerMask mask;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animator animator))
        {
            animator.SetInteger("HitValue", 1);
            Debug.Log("iohje");
        }
    }
}
