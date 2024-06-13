using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StealthKill : MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask layerMask;


    private void OnEnable()
    {
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Update()
    {
       // PlayerDetection();
    }
    public void PlayerDetection()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                Debug.Log("Hit object: " + hitCollider.gameObject.name);
               
                
                    Vector3 direction= (hitCollider.transform.position-PlayerManger.instance.controllerInstance.transform.position).normalized;
                    Debug.Log(Vector3.Dot(hitCollider.transform.forward, direction));
                
            }
        }
        else
        {
            Debug.Log("No objects detected within the sphere.");
        }
    }
    public Transform EnemyRef;
    public void TakeDown(InputAction.CallbackContext context)
    {

    }
}
