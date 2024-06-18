using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyData : MonoBehaviour
{
    //public static EnemyData EnemyDataInstance;
    public EnemyData EData;

    public float walkSpeed;
    public float chaseSpeed;
    public float minDistanceWalk, maxDistanceWalk,chaseDistance,attackDistance;
    public Transform player;
    [HideInInspector] public NavMeshAgent agent;
    public int ID;

    public Animator animator;

    public float Health = 100f;
    public Collider SwordCollider;
    public EnemySwordDetect detect;

    public int hitValue; 
    private void OnEnable()
    {
        agent=GetComponent<NavMeshAgent>();
        minDistanceWalk = agent.stoppingDistance;
        animator=GetComponent<Animator>();
        //transform.GetComponent<Animator>().CrossFade("LoadState",1);
        //player=GameObject.FindWithTag("Player").GetComponent<Transform>();
        ////EnemyDataInstance = this;
        //Debug.Log(this.gameObject.name);
    }
    public void EnableSwordCollider()
    {
        //SwordCollider.enabled=true;
    }
    public void DisableSwordCollider() { }//SwordCollider.enabled = false; }
}
