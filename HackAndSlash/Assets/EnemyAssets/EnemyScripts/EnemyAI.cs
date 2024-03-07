using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent enemyAgent;
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

   
}
