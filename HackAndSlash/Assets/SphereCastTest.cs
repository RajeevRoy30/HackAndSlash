using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastTest : MonoBehaviour
{
    public float radius = 1.0f;
    public float maxDistance = 10.0f;
    public LayerMask layerMask;
    private RaycastHit hitInfo;

    void Update()
    {
        // Define the origin and direction for the sphere cast
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Perform the sphere cast
        if (Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask))
        {
            // If the sphere cast hits something, log the name of the object
            Debug.Log("Hit: " + hitInfo.collider.name);
        }
    }

    void OnDrawGizmos()
    {
        // Define the origin and direction for the sphere cast
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Draw the initial sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, radius);

        // Draw the line along which the sphere cast is performed
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(origin, origin + direction * maxDistance);

        // Draw the sphere at the maximum distance
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin + direction * maxDistance, radius);

        // If there's a hit, draw the sphere at the hit point
        if (Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(hitInfo.point, radius);
        }
    }
}

