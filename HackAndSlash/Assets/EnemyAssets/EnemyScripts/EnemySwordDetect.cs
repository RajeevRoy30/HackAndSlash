using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordDetect : MonoBehaviour
{
    public Collider detect;
    [SerializeField]EnemyData enemyData;
    private void OnEnable()
    {
        detect = GetComponent<Collider>();
        detectMask = LayerMask.GetMask("Player");
    }
    [SerializeField] LayerMask mask;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Animator animator))
        {
            animator.SetInteger("HitValue", enemyData.hitValue);
            Debug.Log(enemyData.hitValue);
        }
    }

    [Header("DetectionSystem")]
    [SerializeField] int detectMask;
    [SerializeField] float radius;
    [SerializeField] Vector3 offset;
    Collider[] hitColliders;

    public Collider SwordDetectEnemy()
    {
        hitColliders = Physics.OverlapSphere(transform.position+offset, radius, detectMask);
        foreach (Collider collider in hitColliders) 
        {
            if(collider)
            {
                Debug.Log(collider.gameObject);
                return collider;
            }
        }
        return null;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireSphere(transform.position+ offset, radius);
    }
    
}
