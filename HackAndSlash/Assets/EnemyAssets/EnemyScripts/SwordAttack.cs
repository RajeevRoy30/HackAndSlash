using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            
            Debug.Log("attacked");
        }
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
