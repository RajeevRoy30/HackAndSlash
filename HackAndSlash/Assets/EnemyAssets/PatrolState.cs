using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    float speed = 5f;
    [Range(0f, 100f)]
    public float timeToPatrol;

    public List<Transform> Waypoints = new List<Transform>();

    bool check;

    NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent= animator.GetComponent<NavMeshAgent>();   

        timer = 0;
        if (!check)
        {
            check = true;

            GameObject go = GameObject.FindGameObjectWithTag("Waypoints");

            foreach (Transform t in go.transform)

                Waypoints.Add(t);
        }

        agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        
            agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
        
        timer += Time.deltaTime;
        if(timer > timeToPatrol)
            animator.SetBool("IsPatrolling", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
