using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    public static EnemyHolder instance;
    //public GameObject[] enemyDatas = new GameObject[10];
    public List<EnemyData> data;
    //public int EnemyIdleID = Animator.StringToHash("EnemyIdle");
    //public int EnemyChseeID = Animator.StringToHash("EnemyWalk");
    //public int EnemyWalkID = Animator.StringToHash("EnemyChase");
    //public int EnemyHitID = Animator.StringToHash("EnemyHit");
    //public int EnemyAttackID = Animator.StringToHash("EnemyAttack");
    public Transform player;
    private void OnEnable()
    {
        instance = this;
        //enemyDatas  = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < transform.childCount; i++)
        {
            data.Add(transform.GetChild(i).transform.GetComponent<EnemyData>());
            transform.GetChild(i).transform.GetComponent<EnemyData>().ID = i;
        }
        player =GameObject.FindWithTag("Player").GetComponent<Transform>();
        //enemyDatas.Add(t);
    }
    public float CalculateDistance(Vector3 enemy)
    {
        return Vector3.Distance(player.position, enemy);
    }
    private void Update()
    {

        //Debug.Log( CalculateDistance(transform.position));
    }
    Vector3 lookAt=Vector3.zero;
    public void EnemyLookAt(Transform Enemy)
    {
        lookAt = player.position;
        lookAt.y = Enemy.position.y;
        Enemy.LookAt(lookAt);
    }
}
