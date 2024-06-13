using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t1,t2;
    public Vector3 temp1, temp2;
    public Quaternion q1, q2;
    void Start()
    {
        temp1=t1.position ; temp2=t2.position ;
        q1 = t1.rotation ; q2=t2.rotation ;
    }

    // Update is called once per frame
    public Vector3 offset;
    public float dis;
    public float radius;
    void Update()
    {
        if (Physics.SphereCast(transform.position, radius, Vector3.forward, out RaycastHit hitInfo, dis, 11))
        {
            if(hitInfo.collider != null) { Debug.Log(hitInfo.collider.gameObject.name); }
           
        }
    }

    public void StealthTakeDown()
    {
        t1.transform.GetComponent<Animator>().SetTrigger("Stealth");
        t2.transform.GetComponent<Animator>().SetTrigger("TakeDown");
    }
    public void positionReset()
    {
        Debug.LogError("Disable");
        t1.position =temp1 ; t2.position = temp2 ;t1.rotation =q1 ; t2.rotation = q2 ;
       
    }
}
