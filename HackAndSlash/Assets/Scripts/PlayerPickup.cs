//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerPickup : MonoBehaviour
//{
//    void OnTriggerEnter(Collider other)
//    {
//        Debug.Log(other.gameObject.name);
//        if (other.gameObject.CompareTag("Player"))
//        {
//            Inventory.instance.AddItem(item);
//            Destroy(gameObject);
//        }
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        Debug.Log(collision.gameObject.name);
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Inventory.instance.AddItem(item);
//            Destroy(gameObject);
//        }
//    }
//}
