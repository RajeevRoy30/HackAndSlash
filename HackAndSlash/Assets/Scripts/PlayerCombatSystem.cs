using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerCombatSystem : MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask layerMask;
    Collider [] hitColliders=new Collider[50];
    int count;
    public List<GameObject> Objects;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Update()
    {
        PlayerDetection();
    }
    public void PlayerDetection()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, radius, hitColliders, layerMask);
        Objects.Clear();
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = hitColliders[i].gameObject;
            Objects.Add(obj);

        }
    }
    public Transform EnemyRef;
    public void TakeDown(InputAction.CallbackContext context)
    {

    }
}
