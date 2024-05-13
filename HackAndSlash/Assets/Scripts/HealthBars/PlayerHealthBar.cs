using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    private float _health = 100;
    public float Health { get => this._health=Mathf.Clamp(this._health,0,100); set => this._health = value; }
    public bool hitDetect;
    public void ApplyKnockBackForce(Rigidbody rb)
    {
         hitDetect=true;
    }

    //IEnumerator KnockBackForce(Rigidbody rigidbody) 
    //{
    //    rigidbody.isKinematic=false;

    //}
}
