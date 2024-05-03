using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK,
    DEAD,
    NONE
}
public class EnemyAI : MonoBehaviour
{
    //this enemy is done using finite state machine
    private NavMeshAgent enemyAgent;
    public UnityAction EnemyEvents;

    //idle

    //patrol
    public List<Transform> enemyWayPoints;


    //chase


    //Attack
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
       

        
    }


    void EnemyPatrol()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in go.transform)
            enemyWayPoints.Add(t);
        enemyAgent.SetDestination(enemyWayPoints[Random.Range(0, enemyWayPoints.Count)].position);
    }
   
}
